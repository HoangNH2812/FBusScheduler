using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.Repository;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Service.Service
{
    public class StationsService
    {
        private readonly StationRepository _repository;

        public StationsService()
        {
            _repository = new StationRepository();
        }

        public List<Station> GetStations()
        {
            return _repository.ListProducts().ToList();
        }

        public void CreateStation(Station station)
        {
            _repository.CreateProduct(station);
        }

        public void UpdateStation(Station station)
        {
            _repository.UpdateProduct(station);
        }

        public void DeleteStation(long id)
        {
            _repository.DeleteProduct(id);
        }

        public Station GetStationById(long id)
        {
            return _repository.RetrieveProduct(id).Result;
        }

        public int CountStations()
        {
            return _repository.CountProducts();
        }
    }
}
