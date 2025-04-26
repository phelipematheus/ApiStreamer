using System.Diagnostics;
using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using CrossCutting.Exceptions;
using CrossCutting;

namespace Web.Middlewares
{
    /// <summary>
    /// Middleware que manipula exceções e serializa uma resposta em JSON padronizada.
    /// </summary>
    public sealed class ErrorHandling : IMiddleware
    {
        private readonly ILogger<ErrorHandling> _logger;

        public ErrorHandling(ILogger<ErrorHandling> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Chama o próximo middleware na cadeia de middlewares e lida com exceções, se elas ocorrerem.
        /// </summary>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                await HandleExceptionAsync(context, e);
            }
        }

        /// <summary>
        /// Manipula a exceção e escreve a resposta serializada em JSON na resposta HTTP.
        /// </summary>
        public static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            // Cria um objeto ErrorDetail que contém informações sobre a exceção.
            var response = new ErrorDetail
            {
                Code = exception.GetType().Name,
                Title = GetTitle(exception),
                Detail = GetMessage(exception),
                Errors = GetErrors(exception),
                Instance = httpContext.Request.Path,
                Status = (int)statusCode,
                Extensions =
                {
                    ["traceId"] = Activity.Current?.Id ?? httpContext.TraceIdentifier,
                },
                Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/" + (int)statusCode,
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)statusCode;

            JsonSerializerOptions jsonSerializerOptions = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            JsonSerializerOptions options = jsonSerializerOptions;

            // Serializa a resposta em JSON e a escreve na resposta HTTP.
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }

        /// <summary>
        /// Obtém os erros de exceção e retorna como uma lista de ValidationFailures.
        /// </summary>
        public static IDictionary<string, string[]>? GetErrors(Exception exception)
        {
            IDictionary<string, string[]> errors = new Dictionary<string, string[]>();

            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            if (exception is BaseException baseException && baseException.Errors != null)
            {
                errors = baseException.Errors
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
            }

            return errors;
        }

        /// <summary>
        /// Obtém o status code HTTP da exceção.
        /// </summary>
        public static HttpStatusCode GetStatusCode(Exception ex) => ex switch
        {
            KeyNotFoundException => HttpStatusCode.NotFound,
            FormatException => HttpStatusCode.BadRequest,
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            AuthenticationException => HttpStatusCode.Forbidden,
            ValidationException => HttpStatusCode.UnprocessableEntity,
            ExternalApiException externalApiException => externalApiException.StatusCode,
            BaseException baseException => baseException.StatusCode,
            _ => HttpStatusCode.InternalServerError
        };

        /// <summary>
        /// Obtém o título da exceção.
        /// </summary>
        public static string GetTitle(Exception exception) =>
              exception switch
              {
                  ApplicationException applicationException => applicationException.Message,
                  ValidationException => "Validation Failure",
                  KeyNotFoundException => "Not Found",
                  FormatException => "Bad Request",
                  UnauthorizedAccessException => "Unauthorized",
                  ExternalApiException externalApiException => externalApiException.Title,
                  BaseException baseException => baseException.Title,
                  _ => "Server Error"
              };

        /// <summary>
        /// Obtém a mensagem da exceção.
        /// </summary>
        public static string GetMessage(Exception exception) =>
               exception switch
               {
                   ApplicationException applicationException => applicationException.Message,
                   ValidationException validationException => validationException.Message,
                   KeyNotFoundException notFoundException => notFoundException.Message,
                   FormatException badRequestException => badRequestException.Message,
                   UnauthorizedAccessException unauthorizedException => unauthorizedException.Message,
                   ExternalApiException externalApiException => externalApiException.Message,
                   BaseException baseException => baseException.Message,
                   _ => "Server Error - " + exception.Message
               };
    }
}
