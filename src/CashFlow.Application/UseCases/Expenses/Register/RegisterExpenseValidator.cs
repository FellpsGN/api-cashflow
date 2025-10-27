using CashFlow.Communication.Requests;
using FluentValidation;
namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("Title must not be empty.");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date must not be in the future.");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Payment Type is not valid.");
    }
}