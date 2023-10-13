using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FbusSchedule_.Service.Service
{
    public class RouteService : IRouteService
    {
        private IUnitOfWork _unitOfWork;
        public RouteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Route entity)
        {
            await _unitOfWork._routeRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<Route> entities)
        {
            await _unitOfWork._routeRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._routeRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(Route entityToDelete)
        {
            var status = _unitOfWork._routeRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
        public async Task<List<Route>> Get(Expression<Func<Route, bool>> filter = null, Func<IQueryable<Route>, IOrderedQueryable<Route>> orderBy = null, params Expression<Func<Route, object>>[] includeProperties)
        {
            var buses = await _unitOfWork._routeRepository
            .Get(filter, orderBy, includeProperties);
            return buses.ToList();
        }
        public Task<Route> GetByID(int id, params Expression<Func<Route, object>>[] includeProperties)
        {
            return _unitOfWork._routeRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(Route entityToUpdate)
        {
            _unitOfWork._routeRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
