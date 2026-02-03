using Day9ofLearning.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<RequestTracker>();

builder.Services.AddTransient<INotificationService, NotificationService>();

builder.Services.AddHttpClient<IPaymentService, PaymentService>();

builder.Services.AddSingleton<ICacheService, CacheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
