using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;

namespace Team6._FbusSchedule_.Service.Service
{
    public class CustomerService 
    {
        CustomerRepository repository;
        public CustomerService()
        {
            repository = new CustomerRepository();
        }
        public List<Customer> GetAll()
        {
            return repository.GetAll().ToList();
        }
        public void Create(Customer obj)
        {
            repository.Create(obj);
        }
        public void Update(Customer obj)
        {
            repository.Update(obj);
        }
        public void Delete(Customer obj)
        {
            repository.Delete(obj);
        }
    }
}
