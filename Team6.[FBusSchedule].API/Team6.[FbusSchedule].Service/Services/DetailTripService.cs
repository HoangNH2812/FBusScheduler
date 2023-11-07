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
    public class DetailTripService : IDetailTripService
    {
        private IUnitOfWork _unitOfWork;

        public DetailTripService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(DetailTrip entity)
        {
            await _unitOfWork._detailTripRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<DetailTrip> entities)
        {
            await _unitOfWork._detailTripRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._detailTripRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(DetailTrip entityToDelete)
        {
            var status = _unitOfWork._detailTripRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<List<DetailTrip>> Get(Expression<Func<DetailTrip, bool>> filter = null, Func<IQueryable<DetailTrip>, IOrderedQueryable<DetailTrip>> orderBy = null, params Expression<Func<DetailTrip, object>>[] includeProperties)
        {
            var detailTrips = await _unitOfWork._detailTripRepository.Get(filter, orderBy, includeProperties);
            return detailTrips.ToList();
        }

        public Task<DetailTrip> GetByID(int id, params Expression<Func<DetailTrip, object>>[] includeProperties)
        {
            return _unitOfWork._detailTripRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(DetailTrip entityToUpdate)
        {
            _unitOfWork._detailTripRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
        public async Task<DetailTrip> GetByTripAndStationId(int tripid, int stationid)
        {
            return await _unitOfWork._detailTripRepository.GetByTripAndStationId(tripid, stationid);
        }
    }
}
