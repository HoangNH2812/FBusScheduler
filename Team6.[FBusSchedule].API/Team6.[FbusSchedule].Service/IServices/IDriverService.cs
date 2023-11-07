using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface IDriverService
    {
        Task<List<Driver>> Get(Expression<Func<Driver, bool>> filter = null,
        Func<IQueryable<Driver>, IOrderedQueryable<Driver>> orderBy = null,
        params Expression<Func<Driver, object>>[] includeProperties);
        Task<Driver> GetByID(int id
            , params Expression<Func<Driver, object>>[] includeProperties);
        Task AddAsync(Driver entity);
        Task AddRangeAsync(List<Driver> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Driver entityToDelete);
        Task UpdateAsync(Driver entityToUpdate);
        void Dispose();
        Task<bool> IsEmailUnique(string email);
    }
}
