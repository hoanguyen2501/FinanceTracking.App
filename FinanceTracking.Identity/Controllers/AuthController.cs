using FinanceTracking.Identity.DTOs;
using FinanceTracking.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                AppUser user = new()
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };

                IdentityResult createdUser = await _userManager.CreateAsync(user, registerDto.Password);
                if (!createdUser.Succeeded)
                    return StatusCode(500, createdUser.Errors);

                IdentityResult roleResult = await _userManager.AddToRoleAsync(user, "Admin");
                if (!roleResult.Succeeded)
                    return StatusCode(500, roleResult.Errors);

                return Ok(new
                {
                    Message = "User created.",
                    Data = user,
                });

            }
            catch (Exception exception)
            {
                return StatusCode(500, exception);
            }
        }
    }
}