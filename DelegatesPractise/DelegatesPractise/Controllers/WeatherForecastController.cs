using DelegatesPractise.Domain;
using DelegatesPractise.Publisher;
using DelegatesPractise.Subscribers;
using Microsoft.AspNetCore.Mvc;

namespace DelegatesPractise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
            var orderService = new OrderService();

            var email = new EmailService();
            var sms = new SmsService();
            var audit = new AuditService();

            orderService.OrderPlaced += email.OnOrderPlaced;
            orderService.OrderPlaced += sms.OnOrderPlaced;
            orderService.OrderPlaced += audit.OnOrderPlaced;

            orderService.PlaceOrder(new Order(101, 5000));

        }
    }
}
