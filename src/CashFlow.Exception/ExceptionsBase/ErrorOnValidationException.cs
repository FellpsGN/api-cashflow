using System.Net;

namespace CashFlow.Exception.ExceptionsBase;

public class ErrorOnValidationException : CashFlowException
{
    private readonly List<string> _errorMessages;

    public ErrorOnValidationException(List<string> errorMessage) : base(string.Empty)
    {
        _errorMessages = errorMessage;
    }
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public override List<string> GetErrors() =>  _errorMessages;
} /* Minuto: 10:43 */