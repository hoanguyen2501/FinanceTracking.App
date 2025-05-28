using FinanceTracking.Identity.Entities;
using FinanceTracking.Identity.Models;
using FinanceTracking.Identity.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;

        public AuthController(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            var user = new User { UserName = dto.Email, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "User"); // Default role
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded) return Unauthorized();

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateToken(user);

            return Ok(new
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email,
                Roles = roles,
                AccessToken = token,
            });
        }
    }

}