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
        private readonly IDriverService _driverService;
        private readonly string _secretKey;

        public authController(ICustomerService customerService, IDriverService driverService, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _customerService = customerService;
            _driverService = driverService;
            _secretKey = optionsMonitor.CurrentValue.SecretKey.IsNullOrEmpty() ? "" : optionsMonitor.CurrentValue.SecretKey;
        }

        [HttpPost("customerLogin")]
        public async Task<IActionResult> CustomerLogin(LoginVM model)
        {
            var isAuthenticatedCustomer = await _customerService.Get(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password));
            if (isAuthenticatedCustomer == null)
                return Unauthorized("Invalid email or password.");

            return Ok(new ApiResponse()
            {
                Success = true,
                Messsage = "Authenticate succsess",
                Data = GenerateTokenForCustomer(isAuthenticatedCustomer.FirstOrDefault(), _secretKey)
            });
        }

        private static string GenerateTokenForCustomer(Customer customer, string _secretKey)
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

        [HttpPost("driverLogin")]
        public async Task<IActionResult> DriverLogin(LoginVM model)
        {
            var isAuthenticatedDriver = await _driverService.Get(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password));
            if (isAuthenticatedDriver == null)
                return Unauthorized("Invalid email or password.");

            return Ok(new ApiResponse()
            {
                Success = true,
                Messsage = "Authenticate succsess",
                Data = GenerateTokenForDriver(isAuthenticatedDriver.FirstOrDefault(), _secretKey)
            });
        }

        private static string GenerateTokenForDriver(Driver driver, string _secretKey)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, driver.DriverName),
                    new Claim("Email", driver.Email),
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