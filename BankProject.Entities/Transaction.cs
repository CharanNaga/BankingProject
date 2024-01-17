namespace BankProject.Entities
{
    public class Transaction
    {
        public Guid TransactionID { get; set; }
        public Guid SourceAccountID { get; set; }
        public Guid DestinationAccountID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
