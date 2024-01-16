using BankProject.Configuration;
using BankProject.Entities;
using BankProject.Exceptions;
using BankProject.Repositories;
using BankProject.RepositoryContracts;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;
using BankProject.Services.Helpers;

namespace BankProject.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;

        public AccountsService(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public AccountResponse AddAccount(AccountAddRequest? accountAddRequest)
        {
            try
            {
                //1. check for null condition for accountaddrequest
                if (accountAddRequest == null)
                {
                    throw new ArgumentNullException(nameof(accountAddRequest));
                }

                //2. validate all properties of accountaddrequest
                ValidationHelper.ModelValidation(accountAddRequest);

                //3. convert accountaddrequest to account type
                Account account = accountAddRequest.ToAccount();

                //4. create new accountid
                account.AccountID = Guid.NewGuid();

                //get all accounts
                List<Account> accounts = _accountsRepository.GetAccounts();
                long maximumAccountNumber = 0;

                foreach (var item in accounts)
                {
                    if (item.AccountNumber > maximumAccountNumber)
                    {
                        maximumAccountNumber = item.AccountNumber;
                    }
                }
                //generate new account number
                if (accounts.Count >= 1)
                {
                    account.AccountNumber = maximumAccountNumber + 1;
                }
                else
                {
                    account.AccountNumber = Settings.BaseAccountNumber + 1;
                }

                account.Balance = 0.0M;

                //5. Then invoke corresponding repository
                _accountsRepository.AddAccount(account);

                //6. return accountresponse object with newly generated accountid
                return account.ToAccountResponse();
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

        public bool DeleteAccount(Guid? accountID)
        {
            try
            {
                //1. check null conditionality for accountid
                if (accountID == null)
                {
                    throw new ArgumentNullException(nameof(accountID));
                }

                //2. invoke corresponding repository method
                bool isDeleted = _accountsRepository.DeleteAccount(accountID.Value);

                //3. return boolean value indicating account object is deleted or not
                return isDeleted;
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

        public List<AccountResponse> GetAccounts()
        {
            try
            {
                var accounts =  _accountsRepository.GetAccounts();
                return accounts.Select(temp => temp.ToAccountResponse()).ToList();
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

        public List<AccountResponse> GetFilteredAccounts(Predicate<Account> condition)
        {
            throw new NotImplementedException();
        }

        public AccountResponse UpdateAccount(AccountUpdateRequest? accountUpdateRequest)
        {
            try
            {
                //1. check for null condition for accountupdaterequest
                if (accountUpdateRequest == null)
                {
                    throw new ArgumentNullException(nameof(accountUpdateRequest));
                };

                //2. validate all properties of accountupdaterequest
                ValidationHelper.ModelValidation(accountUpdateRequest);

                //3. convert accountupdaterequest to account type
                Account account = accountUpdateRequest.ToAccount();

                //4. invoke corresponding repository method
                var updatedAccount = _accountsRepository.UpdateAccount(account);

                //5. check for null conditionality
                if (updatedAccount == null)
                {
                    throw new AccountException("No matching Account found.");
                }

                //5. convert account object to accountresponse object & return the accountresponse object
                return updatedAccount.ToAccountResponse();
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
    }
}
