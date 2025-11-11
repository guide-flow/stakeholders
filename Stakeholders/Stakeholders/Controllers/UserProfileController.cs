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
            var username = User.FindFirstValue(ClaimTypes.Email);
            var role = User.FindFirstValue(ClaimTypes.Role);
            return Task.FromResult<IActionResult>(Ok(new
            {
                Message = "Admin profile accessed",
                Username = username,
                Role = role
            }));
        }
        [Authorize]
        [HttpPost("create-user-profile")]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileDto userProfileDto)
        {
            if (userProfileDto == null)
            {
                return BadRequest("User profile data is required.");
            }
            var username = Request.Headers["X-User-Email"].ToString();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("Username not found in claims.");
            }
            userProfileDto.Username = username;
            var subValue = Request.Headers["X-User-Id"].ToString();
            if (!long.TryParse(subValue, out var userId))
            {
                return BadRequest("Invalid user id in claims.");
            }
            userProfileDto.Id = userId;

            if (!string.IsNullOrEmpty(userProfileDto.ImageBase64))
            {
                var imageBytes = Convert.FromBase64String(userProfileDto.ImageBase64);
                var fileName = $"{Guid.NewGuid()}.jpg";
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "users");
                Directory.CreateDirectory(folderPath);
                var filePath = Path.Combine(folderPath, fileName);
                await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);
                userProfileDto.ProfilePictureUrl = $"/images/users/{fileName}";
            }

            var createdProfile = await _userProfileService.CreateUserProfile(userProfileDto);
            return Ok(createdProfile);
        }

        [Authorize]
        [HttpGet("user-profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var username = Request.Headers["X-User-Email"].ToString();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("Username not found in claims.");
            }
            var userDto = await _userProfileService.GetUserProfile(username);
            return Ok(userDto);
        }

        [Authorize]
        [HttpGet("user-profile/{userId}")]
        public async Task<IActionResult> GetUserProfileById(string userId)
        {
            var userDto = await _userProfileService.GetUserProfileById(userId);
            if (userDto == null)
            {
                return NotFound($"User profile with ID {userId} not found.");
            }
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
            var username = Request.Headers["X-User-Email"].ToString();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("Username not found in claims.");
            }
            userProfileDto.Username = username;

            // Handle image upload if provided
            if (!string.IsNullOrEmpty(userProfileDto.ImageBase64))
            {
                var imageBytes = Convert.FromBase64String(userProfileDto.ImageBase64);
                var fileName = $"{Guid.NewGuid()}.jpg";
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "users");
                Directory.CreateDirectory(folderPath);
                var filePath = Path.Combine(folderPath, fileName);
                await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);
                userProfileDto.ProfilePictureUrl = $"/images/users/{fileName}";
            }

            var updatedProfile = await _userProfileService.UpdateUserProfile(userProfileDto);
            return Ok(updatedProfile);
        }
    }
}
