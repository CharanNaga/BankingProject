using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Exceptions
{
    public class CustomerException : ApplicationException
    {
        public CustomerException():base()
        { 
        }

        public CustomerException(string message) : base(message) 
        {
        }

        public CustomerException(string message,  Exception innerException) : base(message, innerException)
        { 
        }
    }
}
