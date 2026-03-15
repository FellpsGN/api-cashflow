using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _expenseRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public RegisterExpenseUseCase(IExpensesWriteOnlyRepository expenseRepository, IUnityOfWork unityOfWork, IMapper mapper)
    {
        _expenseRepository = expenseRepository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }
    private void Validate(RequestExpenseJson request)
    {
        var expenseValidator = new ExpenseValidator();
        var expenseValidationResult = expenseValidator.Validate(request);

        if (!expenseValidationResult.IsValid)
        {
            var expenseErrorsMessage = expenseValidationResult.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(expenseErrorsMessage);
        }
    }
    public async Task<ResponseRegisterExpenseJson> Execute(RequestExpenseJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);
        
        await _expenseRepository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisterExpenseJson>(entity);
    }
}