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

        public CustomersRepository()
        {
            _customers = new List<Customer>();
        }

        public Customer AddCustomer(Customer customer)
        {
            _customers.Add(customer);
            return customer;
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
            var matchingCustomer =  _customers.Find(temp => temp.CustomerID == customer.CustomerID);
            if (matchingCustomer == null)
            {
                return customer;
            }
            matchingCustomer.CustomerCode = customer.CustomerCode;
            matchingCustomer.CustomerName = customer.CustomerName;
            matchingCustomer.Address = customer.Address;
            matchingCustomer.Landmark = customer.Landmark;
            matchingCustomer.City = customer.City;
            matchingCustomer.Country = customer.Country;
            matchingCustomer.Mobile = customer.Mobile;

            return matchingCustomer;
        }
    }
}
