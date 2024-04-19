using Microsoft.AspNetCore.Mvc;

namespace ServiceDiscoveryTutorials.CatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet("/health")]
        public IActionResult CheckHealth()
        {
            // Implement health check logic
            return Ok("Healthy");
        }
    }
}
