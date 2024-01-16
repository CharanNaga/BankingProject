using BankProject.Entities;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;

namespace BankProject.Services
{
    public class AccountsService : IAccountsService
    {
        public AccountResponse AddAccount(AccountAddRequest? accountAddRequest)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(Guid? accountID)
        {
            throw new NotImplementedException();
        }

        public List<AccountResponse> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public List<AccountResponse> GetFilteredAccounts(Predicate<Account> condition)
        {
            throw new NotImplementedException();
        }

        public AccountResponse UpdateAccount(AccountUpdateRequest? accountUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
