using BankProject.Entities;
using BankProject.ServiceContracts.Dto;

namespace BankProject.ServiceContracts
{
    public interface IAccountsService
    {
        AccountResponse AddAccount(AccountAddRequest? accountAddRequest);

        List<AccountResponse> GetAccounts();

        List<AccountResponse> GetFilteredAccounts(Predicate<Account> condition);

        AccountResponse UpdateAccount(AccountUpdateRequest? accountUpdateRequest);

        bool DeleteAccount(Guid? accountID);
    }
}
