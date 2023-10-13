using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FbusSchedule_.Service.Services
{
    public class TripService : ITripService
    {
        private IUnitOfWork _unitOfWork;

        public TripService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Trip entity)
        {
            await _unitOfWork._tripRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<Trip> entities)
        {
            await _unitOfWork._tripRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._tripRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(Trip entityToDelete)
        {
            var status = _unitOfWork._tripRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<List<Trip>> Get(Expression<Func<Trip, bool>> filter = null, Func<IQueryable<Trip>, IOrderedQueryable<Trip>> orderBy = null, params Expression<Func<Trip, object>>[] includeProperties)
        {
            var trips = await _unitOfWork._tripRepository.Get(filter, orderBy, includeProperties);
            return trips.ToList();
        }

        public Task<Trip> GetByID(int id, params Expression<Func<Trip, object>>[] includeProperties)
        {
            return _unitOfWork._tripRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(Trip entityToUpdate)
        {
            _unitOfWork._tripRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
