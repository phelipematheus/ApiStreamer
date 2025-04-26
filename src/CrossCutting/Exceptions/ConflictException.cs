using System.Net;

namespace CrossCutting.Exceptions;

public class ConflictException(string message) : BaseException(message)
{
    public override string Title => "Conflict";
    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
