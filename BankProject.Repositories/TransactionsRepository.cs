using BankProject.Entities;
using BankProject.RepositoryContracts;

namespace BankProject.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        public Transaction AddTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(Guid transactionID)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetFilteredTransactions(Predicate<Transaction> condition)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public Transaction UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
