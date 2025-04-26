using System.Net;

namespace CrossCutting.Exceptions;

public class BadRequestException(string message) : BaseException(message)
{
    public override string Title => "Bad Request";
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
