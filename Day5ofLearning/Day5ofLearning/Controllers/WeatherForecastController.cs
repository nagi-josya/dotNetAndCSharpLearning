using Microsoft.AspNetCore.Mvc;

namespace Day5ofLearning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet("blocking")]
        public IActionResult Blocking()
        {
            // Simulate external I/O
            Thread.Sleep(500);

            return Ok("Done");
        }

        [HttpGet("taskrun")]
        public async Task<IActionResult> TaskRun()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(500);
            });

            return Ok("Done");
        }

    }
}
