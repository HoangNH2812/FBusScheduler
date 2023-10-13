using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FbusSchedule_.Service.Service
{
    public class BusService : IBusService
    {
        private IUnitOfWork _unitOfWork;

        public BusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Bus entity)
        {
            await _unitOfWork._busRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<Bus> entities)
        {
            await _unitOfWork._busRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._busRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(Bus entityToDelete)
        {
            var status = _unitOfWork._busRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
        public async Task<List<Bus>> Get(Expression<Func<Bus, bool>> filter = null, Func<IQueryable<Bus>, IOrderedQueryable<Bus>> orderBy = null, params Expression<Func<Bus, object>>[] includeProperties)
        {
            var buses = await _unitOfWork._busRepository
            .Get(filter, orderBy, includeProperties);
            return buses.ToList();
        }
        public Task<Bus> GetByID(int id, params Expression<Func<Bus, object>>[] includeProperties)
        {
            return _unitOfWork._busRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(Bus entityToUpdate)
        {
            _unitOfWork._busRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
