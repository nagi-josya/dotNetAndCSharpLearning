using Day9ofLearning.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day9ofLearning.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly RequestTracker _tracker;

        public OrdersController(IOrderService orderService, RequestTracker tracker)
        {
            _orderService = orderService;
            _tracker = tracker;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            Console.WriteLine($"Controller RequestId: {_tracker.RequestId}");
            await _orderService.PlaceOrderAsync();
            return Ok("Order placed");
        }
    }

}
