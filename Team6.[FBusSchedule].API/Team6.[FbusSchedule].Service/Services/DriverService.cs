using System;
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
    public class DriverService : IDriverService
    {
        private IUnitOfWork _unitOfWork;
        public DriverService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Driver entity)
        {
            await _unitOfWork._driverRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<Driver> entities)
        {
            await _unitOfWork._driverRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._driverRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(Driver entityToDelete)
        {
            var status = _unitOfWork._driverRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
        public async Task<List<Driver>> Get(Expression<Func<Driver, bool>> filter = null, Func<IQueryable<Driver>, IOrderedQueryable<Driver>> orderBy = null, params Expression<Func<Driver, object>>[] includeProperties)
        {
            var buses = await _unitOfWork._driverRepository
            .Get(filter, orderBy, includeProperties);
            return buses.ToList();
        }
        public Task<Driver> GetByID(int id, params Expression<Func<Driver, object>>[] includeProperties)
        {
            return _unitOfWork._driverRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(Driver entityToUpdate)
        {
            _unitOfWork._driverRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
