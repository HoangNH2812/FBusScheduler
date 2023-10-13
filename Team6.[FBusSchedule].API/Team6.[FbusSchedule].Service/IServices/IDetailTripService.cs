using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.IServices
{
    public interface IDetailTripService
    {
        Task<List<DetailTrip>> Get(Expression<Func<DetailTrip, bool>> filter = null,
        Func<IQueryable<DetailTrip>, IOrderedQueryable<DetailTrip>> orderBy = null,
        params Expression<Func<DetailTrip, object>>[] includeProperties);
        Task<DetailTrip> GetByID(int id
            , params Expression<Func<DetailTrip, object>>[] includeProperties);
        Task AddAsync(DetailTrip entity);
        Task AddRangeAsync(List<DetailTrip> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(DetailTrip entityToDelete);
        Task UpdateAsync(DetailTrip entityToUpdate);
        void Dispose();
    }
}
