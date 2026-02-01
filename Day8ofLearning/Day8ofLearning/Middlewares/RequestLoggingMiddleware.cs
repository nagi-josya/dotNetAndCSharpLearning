namespace Day8ofLearning.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request Path: {context.Request.Path}");

            await _next(context);

            Console.WriteLine($"Response Status: {context.Response.StatusCode}");
        }
    }

}
