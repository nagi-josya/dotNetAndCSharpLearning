using Day10ofLearning.Models;
using Day10ofLearning.Services;
using Day10ofLearning.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Day10ofLearning.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IIdempotencyStore _store;

        public OrdersController(IIdempotencyStore store)
        {
            _store = store;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(
            [FromBody] CreateOrderRequest request,
            [FromHeader(Name = "Idempotency-Key")] string idempotencyKey)
        {
            if (string.IsNullOrWhiteSpace(idempotencyKey))
                return BadRequest("Idempotency-Key header is required.");

            var requestHash = HashHelper.ComputeHash(request);

            var record = _store.GetOrAdd(idempotencyKey, () =>
                new IdempotencyRecord
                {
                    RequestHash = requestHash,
                    IsCompleted = false
                });

            // ❌ Same key, different payload
            if (record.RequestHash != requestHash)
                return Conflict("Idempotency key reused with different payload.");

            // 🔁 Already processed
            if (record.IsCompleted && record.Response != null)
                return Ok(record.Response);

            // 🟡 First execution (or retry while in progress)
            await Task.Delay(1000); // simulate work

            var response = new OrderResponse(
                Guid.NewGuid(),
                "Created"
            );

            record.Response = response;
            record.IsCompleted = true;

            return Ok(response);
        }
    }
}
