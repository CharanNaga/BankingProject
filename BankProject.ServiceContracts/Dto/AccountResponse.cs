using BankProject.Entities;

namespace BankProject.ServiceContracts.Dto
{
    public class AccountResponse
    {
        public Guid CustomerID { get; set; }
        public Guid AccountID { get; set; }
        public long AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(AccountResponse))
                return false;
            AccountResponse response = (AccountResponse)obj;
            return CustomerID == response.CustomerID && 
                AccountID == response.AccountID &&
                AccountNumber == response.AccountNumber &&
                Balance == response.Balance;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Balance for AccountNumber:{AccountNumber} with CustomerID {CustomerID} is:- {Balance}";
        }

        public AccountUpdateRequest ToAccountUpdateRequest()
        {
            return new AccountUpdateRequest()
            {
                AccountID = AccountID,
                AccountNumber = AccountNumber,
                Balance = Balance,
                CustomerID = CustomerID
            };
        }
    }

    public static class AccountExtensions
    {
        public static AccountResponse ToAccountResponse(this Account account)
        {
            return new AccountResponse()
            {
                CustomerID = account.CustomerID,
                AccountID = account.AccountID,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance
            };
        }
    }
}
