using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;
using Team6._FbusSchedule_.Service.IServices;

namespace Team6._FbusSchedule_.Service.Service
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Customer entity)
        {
            await _unitOfWork._customerRepository.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task AddRangeAsync(List<Customer> entities)
        {
            await _unitOfWork._customerRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _unitOfWork._customerRepository.Delete(id);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public async Task<bool> DeleteAsync(Customer entityToDelete)
        {
            var status = _unitOfWork._customerRepository.Delete(entityToDelete);
            await _unitOfWork.SaveChangeAsync();
            return status;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
        public async Task<List<Customer>> Get(Expression<Func<Customer, bool>> filter = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null, params Expression<Func<Customer, object>>[] includeProperties)
        {
            var buses = await _unitOfWork._customerRepository
            .Get(filter, orderBy, includeProperties);
            return buses.ToList();
        }
        public Task<Customer> GetByID(int id, params Expression<Func<Customer, object>>[] includeProperties)
        {
            return _unitOfWork._customerRepository.GetByID(id, includeProperties);
        }

        public async Task UpdateAsync(Customer entityToUpdate)
        {
            _unitOfWork._customerRepository.Update(entityToUpdate);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
