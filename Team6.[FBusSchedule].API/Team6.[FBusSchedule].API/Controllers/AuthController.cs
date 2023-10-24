using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FBusSchedule_.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {
        //private readonly IAuthenticationService _authenticationService;
        private readonly ICustomerService _customerService;
        private readonly string _secretKey;

        public authController(ICustomerService customerService, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _customerService = customerService;
            _secretKey = optionsMonitor.CurrentValue.SecretKey.IsNullOrEmpty() ? "" : optionsMonitor.CurrentValue.SecretKey;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var isAuthenticated = await _customerService.Get(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password));
            if (isAuthenticated == null)
                return Unauthorized("Invalid email or password.");

            return Ok(new ApiResponse()
            {
                Success = true,
                Messsage = "Authenticate succsess",
                Data = GenerateToken(isAuthenticated.FirstOrDefault(), _secretKey)
            });
        }

        private static string GenerateToken(Customer customer, string _secretKey)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, customer.CustomerName),
                    new Claim("Email", customer.Email),
                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.Aes128CbcHmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }

    }
}