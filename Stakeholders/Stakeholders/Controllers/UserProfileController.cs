using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Stakeholders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        [Authorize(Policy = "administratorPolicy")]
        [HttpGet("admin")]
        public Task<IActionResult> GetAdminProfile()
        {
            var username = User.FindFirstValue(ClaimTypes.Name); //Iz nekog razloga ne dobavi ime
            var role = User.FindFirstValue(ClaimTypes.Role);
            return Task.FromResult<IActionResult>(Ok(new
            {
                Message = "Admin profile accessed",
                Username = username,
                Role = role
            }));
        }
        
    }
}
