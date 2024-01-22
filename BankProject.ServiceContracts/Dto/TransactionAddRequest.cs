using BankProject.Entities;

namespace BankProject.ServiceContracts.Dto
{
    public class TransactionAddRequest
    {
        public Guid SourceAccountID { get; set; }
        public Guid DestinationAccountID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }

        public Transaction ToTransaction()
        {
            return new Transaction()
            {
                SourceAccountID = SourceAccountID,
                DestinationAccountID = DestinationAccountID,
                Amount = Amount,
                TransactionDateTime = TransactionDateTime
            };
        }
    }
}
