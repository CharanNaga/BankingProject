using BankProject.Entities;

namespace BankProject.RepositoryContracts
{
    public interface ITransactionsRepository
    {
        List<Transaction> GetTransactions();

        List<Transaction> GetFilteredTransactions(Predicate<Transaction> condition);

        Transaction AddTransaction(Transaction transaction);

        Transaction UpdateTransaction(Transaction transaction);

        bool DeleteTransaction(Guid transactionID);
    }
}
