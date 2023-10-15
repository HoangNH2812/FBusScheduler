using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.IRepositories;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FbusSchedule_.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDriverRepository _driverRepository;

        public AuthenticationService(ICustomerRepository customerRepository, IDriverRepository driverRepository)
        {
            _customerRepository = customerRepository;
            _driverRepository = driverRepository;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            // Check if the email exists in the customer repository
            var customer = await _customerRepository.GetByEmailAsync(email);
            if (customer != null && customer.Password == password)
                return true;

            // Check if the email exists in the driver repository
            var driver = await _driverRepository.GetByEmailAsync(email);
            if (driver != null && driver.Password == password)
                return true;

            return false;
        }
    }
}
