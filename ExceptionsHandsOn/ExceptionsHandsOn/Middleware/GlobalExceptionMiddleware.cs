using ExceptionsHandsOn.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace ExceptionsHandsOn.Api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                    _logger.LogError(ex, "Unhandled Exception Occurred");

                var response = ex switch
                {
                    BusinessRuleException => (HttpStatusCode.BadRequest, ex.Message),
                    NotFoundException => (HttpStatusCode.NotFound, ex.Message),
                    ExternalServiceException => (HttpStatusCode.BadGateway, ex.Message),
                    _ => (HttpStatusCode.InternalServerError, "Internal Server Error")
                };

                context.Response.StatusCode = (int)response.Item1;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    error = response.Item2,
                    traceId = context.TraceIdentifier
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
