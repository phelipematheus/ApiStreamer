using System.Net;

namespace CrossCutting.Exceptions;

public class UnauthorizedException(string message = "Falha na autenticação") : BaseException(message)
{
    public override string Title => "User-ID não encontrado.";
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}
