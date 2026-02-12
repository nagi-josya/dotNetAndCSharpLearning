using ExceptionsHandsOn.Application.Interfaces;
using ExceptionsHandsOn.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionsHandsOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _service.GetOrderAsync(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            await _service.ProcessOrderAsync(order);
            return Ok("Processed");
        }

        [HttpGet("aggregate")]
        public async Task<IActionResult> AggregateDemo()
        {
            await _service.AggregateFailureDemo();
            return Ok();
        }
    }
}
