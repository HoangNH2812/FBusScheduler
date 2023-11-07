using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.ViewModel;

namespace Team6._FbusSchedule_.Repository.IRepositories
{
    public interface ICustomerRepository : IGenericRepository<Customer, int>
    {
        Task<Customer> GetByEmailAsync(string email);
    }
}
