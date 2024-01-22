using BankProject.Entities;
using BankProject.Exceptions;
using BankProject.RepositoryContracts;

namespace BankProject.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly List<Account> _accounts;

        public AccountsRepository()
        {
            _accounts = new List<Account>();
            //_accounts = new List<Account>()
            //{
            //    new Account()
            //    {
            //        AccountID = Guid.Parse("E3B7F3CB-1315-431B-8E60-4FE6D79084C8"),
            //        AccountNumber = 10001,
            //        Balance = 1000,
            //        CustomerID = Guid.Parse("8C12BEA9-8FB0-4744-8422-1996533805E8")
            //    },
            //    new Account() {
            //        AccountID = Guid.Parse("68319657-1FCF-49CC-9193-C4442F55AD28"),
            //        AccountNumber = 10002,
            //        Balance = 500,
            //        CustomerID = Guid.Parse("8C12BEA9-8FB0-4744-8422-1996533805E8")
            //    },
            //};
        }

        public Account AddAccount(Account account)
        {
            try
            {
                _accounts.Add(account);
                return account;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAccount(Guid accountID)
        {
            try
            {
                var matchingAccount = _accounts.Find(temp => temp.AccountID == accountID);
                if (matchingAccount == null)
                {
                    return false;
                }
                _accounts.Remove(matchingAccount);
                return true;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Account> GetAccounts()
        {
            try
            {
                return _accounts;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Account> GetFilteredAccounts(Predicate<Account> condition)
        {
            try
            {
                return _accounts.FindAll(condition);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Account UpdateAccount(Account account)
        {
            try
            {
                var matchingAccount = _accounts.Find(temp => temp.AccountID == account.AccountID);
                if (matchingAccount == null)
                {
                    return account;
                }
                matchingAccount.AccountID = account.AccountID;
                matchingAccount.AccountNumber = account.AccountNumber;
                matchingAccount.CustomerID = account.CustomerID;
                matchingAccount.Balance = account.Balance;

                return matchingAccount;
            }
            catch (AccountException)
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
