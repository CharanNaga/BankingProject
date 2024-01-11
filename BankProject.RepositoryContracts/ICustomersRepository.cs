using BankProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.RepositoryContracts
{
    public interface ICustomersRepository
    {
        List<Customer> GetCustomers();

        List<Customer> GetFilteredCustomers(Predicate<Customer> condition);

        Customer AddCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);

        bool DeleteCustomer(Guid customerID);
    }
}
