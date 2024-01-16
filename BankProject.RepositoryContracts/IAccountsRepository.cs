using BankProject.Entities;

namespace BankProject.RepositoryContracts
{
    public interface IAccountsRepository
    {
        List<Account> GetAccounts();

        List<Account> GetFilteredAccounts(Predicate<Account> condition);

        Account AddAccount(Account account);

        Account UpdateAccount(Account account);

        bool DeleteAccount(Guid accountID);
    }
}
