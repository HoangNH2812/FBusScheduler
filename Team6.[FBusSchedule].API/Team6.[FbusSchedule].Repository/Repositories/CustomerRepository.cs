using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.IRepositories;

namespace Team6._FbusSchedule_.Repository.Repository
{
    public class CustomerRepository : GenericRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(PostgresContext context) : base(context)
        {
        }
        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await dbSet.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
