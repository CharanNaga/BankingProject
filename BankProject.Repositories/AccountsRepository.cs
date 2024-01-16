using BankProject.Entities;
using BankProject.Exceptions;
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
        private readonly List<Account> _accounts;

        public AccountsRepository()
        {
            _accounts = new List<Account>();
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
            catch(Exception)
            {
                throw;
            }
        }

        public bool DeleteAccount(Guid accountID)
        {
            throw new NotImplementedException();
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
            catch(Exception)
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
            catch(AccountException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Account UpdateAccount(Account account)
        {
            try
            {
                var matchingAccount = _accounts.Find(temp=> temp.AccountID ==  account.AccountID);
                if(matchingAccount == null)
                {
                    return account;
                }
                matchingAccount.AccountID = account.AccountID;
                matchingAccount.AccountNumber = account.AccountNumber;
                matchingAccount.CustomerID = account.CustomerID;
                matchingAccount.Balance = account.Balance;

                return matchingAccount;
            }
            catch(AccountException)
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
