using BankProject.Entities;
using BankProject.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly List<Customer> _customers;

        public CustomersRepository(List<Customer> customers)
        {
            _customers = new List<Customer>();
        }

        public Customer AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(Guid customerID)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        public List<Customer> GetFilteredCustomers(Predicate<Customer> condition)
        {
            return _customers.FindAll(condition);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
