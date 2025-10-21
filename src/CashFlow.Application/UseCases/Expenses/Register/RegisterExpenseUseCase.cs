using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    private void Validate(RequestRegisterExpenseJson request)
    {
        var isExpenseTitleEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (isExpenseTitleEmpty) throw new ArgumentNullException("Title can't be empty.");

        if (request.Amount <= 0) throw new ArgumentException("Amount must be positive.");

        var isExpenseDateInFuture = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (isExpenseDateInFuture > 0) throw new ArgumentException("Expenses can't be for the future.");

        var isPaymentTypeDefined = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if (!isPaymentTypeDefined) throw new ArgumentException("PaymentType must be defined.");
    }
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegisterExpenseJson
        {
            
        };
    }
}