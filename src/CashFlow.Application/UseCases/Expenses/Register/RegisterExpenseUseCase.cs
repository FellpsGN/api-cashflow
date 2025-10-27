using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
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
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegisterExpenseJson
        {
            
        };
    }
}