using BankProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.ServiceContracts.Dto
{
    public class CustomerAddRequest
    {
        [Range(0, long.MaxValue, ErrorMessage = "Customer Code should be a positive value")]
        public long CustomerCode { get; set; }

        [Required(ErrorMessage = "Customer Name shouldn't be blank")]
        [StringLength(40, ErrorMessage = "Customer Name consists maximum length of 40")]
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Landmark { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile Number consists of 10 digits only")]
        public string? Mobile { get; set; }

        public Customer ToCustomer()
        {
            return new Customer()
            {
                CustomerCode = CustomerCode,
                CustomerName = CustomerName,
                Address = Address,
                Landmark = Landmark,
                City = City,
                Country = Country,
                Mobile = Mobile
            };
        }
    }
}