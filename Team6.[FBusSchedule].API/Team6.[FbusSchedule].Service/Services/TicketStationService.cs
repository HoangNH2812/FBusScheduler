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
    public class TicketStationService : ITicketStationService
    {
        private IUnitOfWork _unitOfWork;

        public TicketStationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(TicketStation entity)
        {
            await _unitOfWork._ticketStationRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<TicketStation> entities)
        {
            await _unitOfWork._ticketStationRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._ticketStationRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(TicketStation entityToDelete)
        {
            var status = _unitOfWork._ticketStationRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<List<TicketStation>> Get(Expression<Func<TicketStation, bool>> filter = null, Func<IQueryable<TicketStation>, IOrderedQueryable<TicketStation>> orderBy = null, params Expression<Func<TicketStation, object>>[] includeProperties)
        {
            var ticketStations = await _unitOfWork._ticketStationRepository.Get(filter, orderBy, includeProperties);
            return ticketStations.ToList();
        }

        public Task<TicketStation> GetByID(int id, params Expression<Func<TicketStation, object>>[] includeProperties)
        {
            return _unitOfWork._ticketStationRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(TicketStation entityToUpdate)
        {
            _unitOfWork._ticketStationRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
