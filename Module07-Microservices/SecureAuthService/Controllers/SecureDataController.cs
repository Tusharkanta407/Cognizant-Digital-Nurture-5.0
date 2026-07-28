using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureAuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Enforces valid JWT token presence
    public class SecureDataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProtectedInfo()
        {
            return Ok(new { message = "Access granted! You successfully bypassed the microservice gateway auth." });
        }
    }
}