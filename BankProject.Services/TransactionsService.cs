using BankProject.Entities;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;

namespace BankProject.Services
{
    public class TransactionsService : ITransactionsService
    {
        public TransactionResponse AddTransaction(TransactionAddRequest? transactionAddRequest)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(Guid transactionID)
        {
            throw new NotImplementedException();
        }

        public List<TransactionResponse> GetFilteredTransactions(Predicate<Transaction> predicate)
        {
            throw new NotImplementedException();
        }

        public List<TransactionResponse> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public TransactionResponse UpdateTransaction(TransactionUpdateRequest? transactionUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
