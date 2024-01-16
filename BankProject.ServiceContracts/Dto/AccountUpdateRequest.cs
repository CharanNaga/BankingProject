using BankProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.ServiceContracts.Dto
{
    public class AccountUpdateRequest
    {
        public Guid CustomerID { get; set; }
        public Guid AccountID { get; set; }
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
                Balance = Balance,
                AccountID = AccountID
            };
        }
    }
}