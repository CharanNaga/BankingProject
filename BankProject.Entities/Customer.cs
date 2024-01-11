using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace BankProject.Entities
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public long CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Landmark { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Mobile { get; set; }
    }
}
