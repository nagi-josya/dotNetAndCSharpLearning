using Day8ofLearning.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.Map("/health", healthApp =>
{
    healthApp.Run(ctx => ctx.Response.WriteAsync("Healthy"));
});

app.MapControllers();

app.Run();
