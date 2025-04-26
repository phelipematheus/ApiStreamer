namespace CrossCutting.Exceptions;
public class ExternalApiException(string message) : BaseException(message)
{
    public override string Title => "External Api Failed";
}
