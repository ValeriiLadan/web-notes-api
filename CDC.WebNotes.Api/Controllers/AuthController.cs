using CDC.WebNotes.Application.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var claimIdentityTask = _authService.Login(username, password, CookieAuthenticationDefaults.AuthenticationScheme);
            if (claimIdentityTask == null)
            {
                return Unauthorized();
            }

            var claimIdentity = await claimIdentityTask;
            await Request.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

            return Ok();
        }
 
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = await _authService.GetUserByUsernameAsync(username);
            if (user != null)
            { 
                return BadRequest($"User with name {user.Username} already exists");
            }

            await _authService.RegisterUserAsync(username, password);

            return Ok("User registered successfully");
        }
    }
}
