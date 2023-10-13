using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface ICustomerService
    {
        Task<List<Customer>> Get(Expression<Func<Customer, bool>> filter = null,
        Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null,
        params Expression<Func<Customer, object>>[] includeProperties);
        Task<Customer> GetByID(int id
            , params Expression<Func<Customer, object>>[] includeProperties);
        Task AddAsync(Customer entity);
        Task AddRangeAsync(List<Customer> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Customer entityToDelete);
        Task UpdateAsync(Customer entityToUpdate);
        void Dispose();
    }
}
