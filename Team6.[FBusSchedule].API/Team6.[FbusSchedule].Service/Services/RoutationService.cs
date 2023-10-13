using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FbusSchedule_.Service.Services
{
    public class RoutationService : IRoutationService
    {
        private IUnitOfWork _unitOfWork;

        public RoutationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Routation entity)
        {
            await _unitOfWork._routationRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<Routation> entities)
        {
            await _unitOfWork._routationRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._routationRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(Routation entityToDelete)
        {
            var status = _unitOfWork._routationRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<List<Routation>> Get(Expression<Func<Routation, bool>> filter = null, Func<IQueryable<Routation>, IOrderedQueryable<Routation>> orderBy = null, params Expression<Func<Routation, object>>[] includeProperties)
        {
            var routations = await _unitOfWork._routationRepository.Get(filter, orderBy, includeProperties);
            return routations.ToList();
        }

        public Task<Routation> GetByID(int id, params Expression<Func<Routation, object>>[] includeProperties)
        {
            return _unitOfWork._routationRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(Routation entityToUpdate)
        {
            _unitOfWork._routationRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
