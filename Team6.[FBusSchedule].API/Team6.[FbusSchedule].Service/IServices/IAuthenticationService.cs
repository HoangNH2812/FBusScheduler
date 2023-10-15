using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);
    }
}
