using Microsoft.AspNetCore.Mvc;

namespace CrossCutting;

/// <summary>
/// Representa informações sobre uma exceção em uma resposta HTTP.
/// </summary>
public class ErrorDetail : ProblemDetails
{
    public string Code { get; set; } = string.Empty;
    public IDictionary<string, string[]>? Errors { get; set; }
}
