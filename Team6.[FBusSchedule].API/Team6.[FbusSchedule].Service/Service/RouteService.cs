using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;

namespace Team6._FbusSchedule_.Service.Service
{
    public class RouteService
    {
        private readonly RouteRepository _repository;

        public RouteService()
        {
            _repository = new RouteRepository();
        }

        public List<Route> GetRoutes()
        {
            return _repository.ListProducts().ToList();
        }

        public void CreateRoute(Route route)
        {
            _repository.CreateProduct(route);
        }

        public void UpdateRoute(Route route)
        {
            _repository.UpdateProduct(route);
        }

        public void DeleteRoute(long id)
        {
            _repository.DeleteProduct(id);
        }

        public Route GetRouteById(long id)
        {
            return _repository.RetrieveProduct(id).Result;
        }

        public int CountRoutes()
        {
            return _repository.CountProducts();
        }
    }
}
