using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM model)
        {
            bool isAuthenticated = await _authenticationService.AuthenticateAsync(model.Email, model.Password);

            if (!isAuthenticated)
                return Unauthorized("Invalid email or password.");

            return Ok("Authentication successful.");
        }

    }
}