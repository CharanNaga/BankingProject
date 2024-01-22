using BankProject.Entities;

namespace BankProject.ServiceContracts.Dto
{
    public class TransactionUpdateRequest
    {
        public Guid TransactionID { get; set; }
        public Guid SourceAccountID { get; set; }
        public Guid DestinationAccountID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }

        public Transaction ToTransaction()
        {
            return new Transaction()
            {
                TransactionID = TransactionID,
                SourceAccountID = SourceAccountID,
                DestinationAccountID = DestinationAccountID,
                Amount = Amount,
                TransactionDateTime = TransactionDateTime
            };
        }
    }
}
