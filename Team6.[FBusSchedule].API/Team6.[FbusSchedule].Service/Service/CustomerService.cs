using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.Repository;

namespace Team6._FbusSchedule_.Service.Service
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public List<Customer> GetCustomers()
        {
            return _repository.ListProducts().ToList();
        }

        public void CreateCustomer(Customer customer)
        {
            _repository.CreateProduct(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _repository.UpdateProduct(customer);
        }

        public void DeleteCustomer(long id)
        {
            _repository.DeleteProduct(id);
        }

        public Customer GetCustomerById(long id)
        {
            return _repository.RetrieveProduct(id).Result;
        }

        public int CountCustomers()
        {
            return _repository.CountProducts();
        }
    }
}
