using System.Security.Claims;
using System.Text;

namespace Web.Middlewares
{
    /// <summary>
    /// Middleware que registra informações de logging de cada requisição HTTP.
    /// </summary>
    /// <remarks>
    /// Cria uma nova instância do middleware de logging.
    /// </remarks>
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public LoggingMiddleware(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
        }

        /// <summary>
        /// Registra informações de logging de cada requisição HTTP.
        /// </summary>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("HTTP processed a request");

            await next(context);

            _logger.LogInformation("HTTP Request done");

            var request = context.Request;

            var requestLog = new StringBuilder();
            requestLog.AppendLine("Request:");
            requestLog.AppendLine($"HTTP {request.Method} {request.Path}");
            requestLog.AppendLine($"Host: {request.Host}");
            requestLog.AppendLine($"Content-Type: {request.ContentType}");
            requestLog.AppendLine($"User: {request?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "username")?.Value}");
            requestLog.AppendLine($"User-ID: {request?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value}");
            requestLog.AppendLine($"Org-ID: {request?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Equals("org_id"))?.Value}");
            requestLog.AppendLine($"Org-Name: {request?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Equals("org_name"))?.Value}");

            _logger.LogInformation($"{requestLog}");

            var response = context.Response;

            var responseLog = new StringBuilder();
            responseLog.AppendLine("Response:");
            responseLog.AppendLine($"HTTP {response.StatusCode}");
            responseLog.AppendLine($"Content-Type: {response.ContentType}");

            _logger.LogInformation($"{responseLog}");
        }
    }
}
