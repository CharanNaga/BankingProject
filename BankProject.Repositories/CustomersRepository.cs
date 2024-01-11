using BankProject.Entities;
using BankProject.Exceptions;
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
            try
            {
                _customers.Add(customer);
                return customer;
            }
            catch(CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                var matchingCustomer = _customers.Find(temp => temp.CustomerID == customerID);
                if (matchingCustomer == null)
                {
                    return false;
                }

                _customers.Remove(matchingCustomer);
                return true;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch(Exception) 
            {
                throw;
            }
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                return _customers;
            }
            catch (CustomerException)
            { 
                throw; 
            }
            catch(Exception) 
            { 
                throw;
            }
        }

        public List<Customer> GetFilteredCustomers(Predicate<Customer> condition)
        {
            try
            {
                return _customers.FindAll(condition);
            }
            catch(CustomerException)
            {
                throw;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public Customer UpdateCustomer(Customer customer)
        {
            try
            {
                var matchingCustomer = _customers.Find(temp => temp.CustomerID == customer.CustomerID);
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
            catch(CustomerException)
            {
                throw;
            }
            catch( Exception ) 
            { 
                throw;
            }   
        }
    }
}
