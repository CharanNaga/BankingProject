using BankProject.Entities;
using BankProject.ServiceContracts.Dto;

namespace BankProject.ServiceContracts
{
    public interface ITransactionsService
    {
        TransactionResponse AddTransaction(TransactionAddRequest? transactionAddRequest);
        List<TransactionResponse> GetTransactions();
        List<TransactionResponse> GetFilteredTransactions(Predicate<Transaction> predicate);
        TransactionResponse UpdateTransaction(TransactionUpdateRequest? transactionUpdateRequest);
        bool DeleteTransaction(Guid transactionID);
    }
}
