using BankProject.Entities;
using BankProject.Exceptions;
using BankProject.RepositoryContracts;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;
using BankProject.Services.Helpers;

namespace BankProject.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IAccountsRepository _accountsRepository;

        public TransactionsService(ITransactionsRepository transactionsRepository, IAccountsRepository accountsRepository)
        {
            _transactionsRepository = transactionsRepository;
            _accountsRepository = accountsRepository;
        }

        public TransactionResponse AddTransaction(TransactionAddRequest? transactionAddRequest)
        {
            try
            {
                //1. check for null condition for transactionAddRequest
                if(transactionAddRequest == null)
                    throw new TransactionException(nameof(transactionAddRequest));

                //2. validate all properties of transactionAddRequest
                ValidationHelper.ModelValidation(transactionAddRequest);

                //3. convert transactionAddRequest to Transaction type
                Transaction transaction = transactionAddRequest.ToTransaction();

                //4. generate new transactionID
                transaction.TransactionID = Guid.NewGuid();

                //5. performing logic by retrieving the accounts
                var sourceAccount = _accountsRepository.GetFilteredAccounts(temp => temp.AccountID == transaction.SourceAccountID).FirstOrDefault();
                var destinationAccount = _accountsRepository.GetFilteredAccounts(temp => temp.AccountID == transaction.DestinationAccountID).FirstOrDefault();

                if(sourceAccount != null && destinationAccount != null)
                {
                    if (sourceAccount.Balance < transaction.Amount)
                    {
                        throw new TransactionException($"Source account has insuffient funds for transaction of {transaction.Amount}");
                    }

                    sourceAccount.Balance -= transaction.Amount;
                    destinationAccount.Balance += transaction.Amount;

                    //6. invoke corresponding repository
                    _transactionsRepository.AddTransaction(transaction);

                    _accountsRepository.UpdateAccount(sourceAccount);
                    _accountsRepository.UpdateAccount(destinationAccount);

                    //7. return transactionresponse object
                    return transaction.ToTransactionResponse();
                }
                throw new TransactionException("Source account or destination account number is invalid");

            }
            catch(TransactionException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool DeleteTransaction(Guid? transactionID)
        {
            try
            {
                //1. check for null condition for transactionID
                if(transactionID == null)
                    throw new TransactionException(nameof(transactionID));

                //2. invoke corresponding repository
                var isDeleted = _transactionsRepository.DeleteTransaction(transactionID.Value);

                //3. return the result
                return isDeleted;
            }
            catch(TransactionException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<TransactionResponse> GetFilteredTransactions(Predicate<Transaction> predicate)
        {
            throw new NotImplementedException();
        }

        public List<TransactionResponse> GetTransactions()
        {
            try
            {
                var allTransactions = _transactionsRepository.GetTransactions();
                return allTransactions.Select(temp => temp.ToTransactionResponse()).ToList();
            }
            catch(TransactionException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public TransactionResponse UpdateTransaction(TransactionUpdateRequest? transactionUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
