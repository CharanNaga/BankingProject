namespace BankProject.Exceptions
{
    public class AccountException : ApplicationException
    {
        public AccountException() : base()
        { 
        }
        public AccountException(string message) : base(message)
        {
        }
        public AccountException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
