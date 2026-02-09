using AutoMapper;

using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public RegisterExpenseUseCase(IExpenseRepository expenseRepository, IUnityOfWork unityOfWork, IMapper mapper)
    {
        _expenseRepository = expenseRepository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }
    private void Validate(RequestRegisterExpenseJson request)
    {
        var expenseValidator = new RegisterExpenseValidator();
        var expenseValidationResult = expenseValidator.Validate(request);

        if (!expenseValidationResult.IsValid)
        {
            var expenseErrorsMessage = expenseValidationResult.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException { ErrorMessages = expenseErrorsMessage };
        }
    }
    public async Task<ResponseRegisterExpenseJson> Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);
        
        await _expenseRepository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisterExpenseJson>(entity);
    }
}