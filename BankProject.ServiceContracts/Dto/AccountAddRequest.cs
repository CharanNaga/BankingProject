using BankProject.Entities;
using System.ComponentModel.DataAnnotations;

namespace BankProject.ServiceContracts.Dto
{
    public class AccountAddRequest
    {
        public Guid CustomerID { get; set; }
        [Range(0, long.MaxValue, ErrorMessage = "Account Number can't be negative")]
        public long AccountNumber { get; set; }
        [Range(0, long.MaxValue, ErrorMessage = "Balance can't be negative")]
        public decimal Balance { get; set; }

        public Account ToAccount()
        {
            return new Account()
            {
                CustomerID = CustomerID,
                AccountNumber = AccountNumber,
                Balance = Balance
            };
        }
    }
}
