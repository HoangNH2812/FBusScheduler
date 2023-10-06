using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;

namespace Team6._FbusSchedule_.Service.Service
{
    public class BusService
    {
        private readonly RepositoryBase<Bus> _repository;

        public BusService()
        {
            _repository = new RepositoryBase<Bus>();
        }

        public List<Bus> GetBuses()
        {
            return _repository.ListProducts().ToList();
        }

        public void CreateBus(Bus bus)
        {
            _repository.CreateProduct(bus);
        }

        public void UpdateBus(Bus bus)
        {
            _repository.UpdateProduct(bus);
        }

        public void DeleteBus(long id)
        {
            _repository.DeleteProduct(id);
        }

        public Bus GetBusById(long id)
        {
            return _repository.RetrieveProduct(id).Result;
        }

        public int CountBuses()
        {
            return _repository.CountProducts();
        }
    }
}
