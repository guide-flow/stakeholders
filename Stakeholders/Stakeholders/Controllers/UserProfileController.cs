using API.Dtos;
using API.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Stakeholders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [Authorize(Policy = "administratorPolicy")]
        [HttpGet("admin")]
        public Task<IActionResult> GetAdminProfile()
        {
            var username = User.FindFirstValue("name"); //Iz nekog razloga ne dobavi ime
            var role = User.FindFirstValue(ClaimTypes.Role);
            return Task.FromResult<IActionResult>(Ok(new
            {
                Message = "Admin profile accessed",
                Username = username,
                Role = role
            }));
        }
        [Authorize]
        [HttpGet("user-profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var username = User.FindFirstValue("name");
            if(string.IsNullOrEmpty(username))
            {
                return Unauthorized("Username not found in claims.");
            }
            var userDto = await _userProfileService.GetUserProfile(username);
            return Ok(userDto);
        }
        [Authorize]
        [HttpPut("user-profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserProfileDto userProfileDto)
        {
            if (userProfileDto == null)
            {
                return BadRequest("User profile data is required.");
            }
            var username = User.FindFirstValue("name");
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("Username not found in claims.");
            }
            userProfileDto.Username = username;
            var updatedProfile = await _userProfileService.UpdateUserProfile(userProfileDto);
            return Ok(updatedProfile);
        }
    }
}
