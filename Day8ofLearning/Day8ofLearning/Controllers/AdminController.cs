using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day8ofLearning.Controllers
{
    [Route("admin")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        [HttpGet("secret")]
        public IActionResult Secret()
        {
            return Ok("Top Secret");
        }
    }
}
