using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day8ofLearning.Controllers
{
    [Route("public")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok("Hello Public");
        }
    }
}
