namespace CashFlow.Exception.ExceptionsBase;

public class ErrorOnValidationException : CashFlowException
{
    public required List<string> ErrorMessages { get; set; } = [];
}