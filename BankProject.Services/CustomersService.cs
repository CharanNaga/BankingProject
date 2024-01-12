﻿using BankProject.Entities;
using BankProject.Exceptions;
using BankProject.Repositories;
using BankProject.RepositoryContracts;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;
using BankProject.Services.Helpers;
using BankProject.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService()
        {
            _customersRepository = new CustomersRepository();
        }
        public CustomerResponse AddCustomer(CustomerAddRequest? customerAddRequest)
        {
            try
            {
                //1. check for null condition for customeraddrequest
                if (customerAddRequest == null)
                {
                    throw new ArgumentNullException(nameof(customerAddRequest));
                }

                //2. validate all properties of customeraddrequest
                ValidationHelper.ModelValidation(customerAddRequest);

                //3. convert customeraddrequest to customer type
                Customer customer = customerAddRequest.ToCustomer();

                //4. create new customerid
                customer.CustomerID = Guid.NewGuid();

                //get all customers
                List<Customer> customers = _customersRepository.GetCustomers();
                long maximumCustomerCode = 0;

                foreach (var item in customers)
                {
                    if (item.CustomerCode > maximumCustomerCode)
                    {
                        maximumCustomerCode = item.CustomerCode;
                    }
                }

                //generate new customer code
                if (customers.Count >= 1)
                {
                    customer.CustomerCode = maximumCustomerCode + 1;
                }
                else
                {
                    customer.CustomerCode = Settings.BaseCustomerNumber + 1;
                }

                //5. Then invoke corresponding repository
                _customersRepository.AddCustomer(customer);

                //6. return customerresponse object with newly generated customerid
                return customer.ToCustomerResponse();
            }
            catch (CustomerException)
            {
                throw;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCustomer(Guid? customerID)
        {
            try
            {
                //1. check null conditionality for customerid
                if (customerID == null)
                {
                    throw new ArgumentNullException(nameof(customerID));
                }

                //2. invoke corresponding repository method
                bool isDeleted = _customersRepository.DeleteCustomer(customerID.Value);

                //3. return boolean value indicating customer object is deleted or not
                return isDeleted;
            }
            catch (CustomerException)
            {
                throw;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<CustomerResponse> GetCustomers()
        {
            try
            {
                var customers = _customersRepository.GetCustomers();
                return customers.Select(c => c.ToCustomerResponse()).ToList();
            }
            catch (CustomerException)
            {
                throw;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<CustomerResponse> GetFilteredCustomers(Predicate<Customer> condition)
        {
            try
            {
                var filteredCustomers = _customersRepository.GetFilteredCustomers(condition);
                return filteredCustomers.Select(c => c.ToCustomerResponse()).ToList();
            }
            catch (CustomerException)
            {
                throw;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public CustomerResponse UpdateCustomer(CustomerUpdateRequest? customerUpdateRequest)
        {
            try
            {
                //1. check for null condition for customerupdaterequest
                if (customerUpdateRequest == null)
                {
                    throw new ArgumentNullException(nameof(customerUpdateRequest));
                };

                //2. validate all properties of customerupdaterequest
                ValidationHelper.ModelValidation(customerUpdateRequest);

                //3. convert customerupdaterequest to customer type
                Customer customer = customerUpdateRequest.ToCustomer();

                //4. invoke corresponding repository method
                var updatedCustomer = _customersRepository.UpdateCustomer(customer);

                //5. check for null conditionality
                if (updatedCustomer == null)
                {
                    throw new CustomerException("No matching customer found.");
                }

                //5. convert customer object to customerresponse object & return the customerresponse object
                return updatedCustomer.ToCustomerResponse();
            }
            catch (CustomerException)
            {
                throw;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
