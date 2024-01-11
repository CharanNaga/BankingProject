using BankProject.ServiceContracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.ServiceContracts
{
    public interface ICustomersService
    {
        CustomerResponse AddCustomer(CustomerAddRequest? customerAddRequest);

        List<CustomerResponse> GetCustomers();

        List<CustomerResponse> GetFilteredCustomers(string searchBy, string searchString);

        CustomerResponse UpdateCustomer(CustomerUpdateRequest? customerUpdateRequest);

        bool DeleteCustomer(Guid? customerID);
    }
}
