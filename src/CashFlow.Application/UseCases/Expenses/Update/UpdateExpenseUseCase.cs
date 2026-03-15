using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Update;

public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IExpensesUpdateOnlyRepository _expenseRepository;
    
    public UpdateExpenseUseCase(IExpensesUpdateOnlyRepository repository, IMapper mapper,  IUnityOfWork unityOfWork)
    {
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _expenseRepository = repository;
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

    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(request);
        var expense = await _expenseRepository.GetById(id);

        if (expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        _mapper.Map(request, expense);
        _expenseRepository.UpdateExpense(expense);
        
        await _unityOfWork.Commit();
    }
}