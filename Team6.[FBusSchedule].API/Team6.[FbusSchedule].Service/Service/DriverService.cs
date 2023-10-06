using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;

namespace Team6._FbusSchedule_.Service.Service
{
    public class DriverService
    {
        private readonly DriverRepository _repository;

        public DriverService()
        {
            _repository = new DriverRepository();
        }

        public List<Driver> GetDrivers()
        {
            return _repository.ListProducts().ToList();
        }

        public async Task<Driver> GetDriverByIdAsync(long id)
        {
            return await _repository.RetrieveProduct(id);
        }

        public void CreateDriver(Driver driver)
        {
            _repository.CreateProduct(driver);
        }

        public void UpdateDriver(Driver driver)
        {
            _repository.UpdateProduct(driver);
        }

        public void DeleteDriver(long id)
        {
            _repository.DeleteProduct(id);
        }

        public int CountDrivers()
        {
            return _repository.CountProducts();
        }
    }
}
