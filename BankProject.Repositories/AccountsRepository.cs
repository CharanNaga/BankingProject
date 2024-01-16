using BankProject.Entities;
using BankProject.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        public Account AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(Guid accountID)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public List<Account> GetFilteredAccounts(Predicate<Account> condition)
        {
            throw new NotImplementedException();
        }

        public Account UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
