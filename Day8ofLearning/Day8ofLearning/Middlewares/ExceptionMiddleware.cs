namespace Day8ofLearning.Middlewares
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught in middleware: {ex.Message}");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var response = new { message = "An unexpected error occurred." };
                var jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);

            }
        }
    }
}
