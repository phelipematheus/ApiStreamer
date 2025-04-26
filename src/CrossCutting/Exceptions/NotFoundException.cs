using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace CrossCutting.Exceptions;

public class NotFoundException(string message) : BaseException(message)
{
    public override string Title => "Not Found";
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public static void ThrowIfListEmpty<T>(IEnumerable<T> list, string message)
    {
        if (!list.Any())
            Throw(message);
    }

    public static void ThrowIfNull([NotNull] object? obj, string objectName, string key)
    {
        ThrowIfNull(obj, $"{objectName} não encontrado com Id: {key}");
    }

    public static void ThrowIfNull([NotNull] object? obj, string message)
    {
        if (obj == null)
            Throw(message);
    }

    [DoesNotReturn]
    private static void Throw(string message)
    {
        throw new NotFoundException(message);
    }
}
