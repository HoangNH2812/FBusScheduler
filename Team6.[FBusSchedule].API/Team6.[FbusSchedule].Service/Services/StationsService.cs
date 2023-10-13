using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Repository;
using Team6._FbusSchedule_.Repository.EntityModel;
using System.Linq.Expressions;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FbusSchedule_.Service.Service
{
    public class StationService : IStationService
    {
        private IUnitOfWork _unitOfWork;
        public StationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Station entity)
        {
            await _unitOfWork._stationRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<Station> entities)
        {
            await _unitOfWork._stationRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._stationRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(Station entityToDelete)
        {
            var status = _unitOfWork._stationRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
        public async Task<List<Station>> Get(Expression<Func<Station, bool>> filter = null, Func<IQueryable<Station>, IOrderedQueryable<Station>> orderBy = null, params Expression<Func<Station, object>>[] includeProperties)
        {
            var buses = await _unitOfWork._stationRepository
            .Get(filter, orderBy, includeProperties);
            return buses.ToList();
        }
        public Task<Station> GetByID(int id, params Expression<Func<Station, object>>[] includeProperties)
        {
            return _unitOfWork._stationRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(Station entityToUpdate)
        {
            _unitOfWork._stationRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
