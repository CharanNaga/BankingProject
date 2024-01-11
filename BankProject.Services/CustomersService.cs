using BankProject.Repositories;
using BankProject.RepositoryContracts;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;
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
            throw new NotImplementedException();
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
