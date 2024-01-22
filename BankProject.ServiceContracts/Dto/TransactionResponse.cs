using BankProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.ServiceContracts.Dto
{
    public class TransactionResponse
    {
        public Guid TransactionID { get; set; }
        public Guid SourceAccountID { get; set; }
        public Guid DestinationAccountID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }

        public TransactionUpdateRequest ToTransactionUpdateRequest()
        {
            return new TransactionUpdateRequest()
            {
                TransactionID = TransactionID,
                SourceAccountID = SourceAccountID,
                DestinationAccountID = DestinationAccountID,
                Amount = Amount,
                TransactionDateTime = TransactionDateTime
            };
        }
    }

    public static class TransactionExtensions
    {
        public static TransactionResponse ToTransactionResponse(this Transaction transaction)
        {
            return new TransactionResponse()
            {
                TransactionID = transaction.TransactionID,
                SourceAccountID = transaction.SourceAccountID,
                DestinationAccountID = transaction.DestinationAccountID,
                Amount = transaction.Amount,
                TransactionDateTime = transaction.TransactionDateTime
            };
        }
    }
}
