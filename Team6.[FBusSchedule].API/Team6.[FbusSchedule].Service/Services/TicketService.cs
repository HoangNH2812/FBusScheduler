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
    public class TicketService : ITicketService
    {
        private IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Ticket entity)
        {
            await _unitOfWork._ticketRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<Ticket> entities)
        {
            await _unitOfWork._ticketRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._ticketRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(Ticket entityToDelete)
        {
            var status = _unitOfWork._ticketRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<List<Ticket>> Get(Expression<Func<Ticket, bool>> filter = null, Func<IQueryable<Ticket>, IOrderedQueryable<Ticket>> orderBy = null, params Expression<Func<Ticket, object>>[] includeProperties)
        {
            var tickets = await _unitOfWork._ticketRepository.Get(filter, orderBy, includeProperties);
            return tickets.ToList();
        }

        public Task<Ticket> GetByID(int id, params Expression<Func<Ticket, object>>[] includeProperties)
        {
            return _unitOfWork._ticketRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(Ticket entityToUpdate)
        {
            _unitOfWork._ticketRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
        public async Task<int> CountByTripId(int tripId)
        {
            // Triển khai đếm số lượng vé dựa trên tripId ở đây
            int ticketCount = await _unitOfWork._ticketRepository.CountByTripId(tripId);
            return ticketCount;
        }
    }
}
