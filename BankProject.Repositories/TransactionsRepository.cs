using BankProject.Entities;
using BankProject.Exceptions;
using BankProject.RepositoryContracts;
using System.Security.Principal;

namespace BankProject.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionsRepository(List<Transaction> transactions)
        {
            _transactions = transactions;
        }


        public Transaction AddTransaction(Transaction transaction)
        {
            try
            {
                _transactions.Add(transaction);
                return transaction;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteTransaction(Guid transactionID)
        {
            try
            {
                var matchingTransaction = _transactions.Find(temp => temp.TransactionID == transactionID);
                if (matchingTransaction == null)
                {
                    return false;
                }
                _transactions.Remove(matchingTransaction);
                return true;
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

        public List<Transaction> GetFilteredTransactions(Predicate<Transaction> condition)
        {
            try
            {
                return _transactions.FindAll(condition);
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

        public List<Transaction> GetTransactions()
        {
            try
            {
                return _transactions;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Transaction UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
