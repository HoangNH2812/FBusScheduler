using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface IStationService
    {
        Task<List<Station>> Get(Expression<Func<Station, bool>> filter = null,
        Func<IQueryable<Station>, IOrderedQueryable<Station>> orderBy = null,
        params Expression<Func<Station, object>>[] includeProperties);
        Task<Station> GetByID(int id
            , params Expression<Func<Station, object>>[] includeProperties);
        Task AddAsync(Station entity);
        Task AddRangeAsync(List<Station> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Station entityToDelete);
        Task UpdateAsync(Station entityToUpdate);
        void Dispose();
    }
}
