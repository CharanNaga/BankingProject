using BankProject.Entities;
using BankProject.Repositories;
using BankProject.RepositoryContracts;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;
using BankProject.Services.Helpers;
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
            //1. check for null condition for customeraddrequest
            if(customerAddRequest == null)
            { 
                throw new ArgumentNullException(nameof(customerAddRequest)); 
            }

            //2. validate all properties of customeraddrequest
            ValidationHelper.ModelValidation(customerAddRequest);

            //3. convert customeraddrequest to customer type
            Customer customer = customerAddRequest.ToCustomer();

            //4. create new customerid
            customer.CustomerID = Guid.NewGuid();

            //5. Then invoke corresponding repository
            _customersRepository.AddCustomer(customer);

            //6. return customerresponse object with newly generated customerid
            return customer.ToCustomerResponse();
        }

        public bool DeleteCustomer(Guid? customerID)
        {
            throw new NotImplementedException();
        }

        public List<CustomerResponse> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public List<CustomerResponse> GetFilteredCustomers(string searchBy, string searchString)
        {
            throw new NotImplementedException();
        }

        public CustomerResponse UpdateCustomer(CustomerUpdateRequest? customerUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
