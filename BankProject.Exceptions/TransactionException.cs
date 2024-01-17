﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Exceptions
{
    public class TransactionException : ApplicationException
    {
        public TransactionException() : base()
        {
        }
        public TransactionException(string message) : base(message)
        {
        }
        public TransactionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
