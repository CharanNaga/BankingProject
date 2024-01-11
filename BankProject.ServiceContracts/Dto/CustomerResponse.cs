using BankProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.ServiceContracts.Dto
{
    public class CustomerResponse
    {
        public Guid CustomerID { get; set; }
        public long CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Landmark { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Mobile { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(CustomerResponse)) return false;
            CustomerResponse customerResponse = (CustomerResponse)obj;

            return CustomerID == customerResponse.CustomerID &&
                CustomerCode == customerResponse.CustomerCode &&
                CustomerName == customerResponse.CustomerName &&
                Address == customerResponse.Address &&
                Landmark == customerResponse.Landmark &&
                City == customerResponse.City &&
                Country == customerResponse.Country &&
                Mobile == customerResponse.Mobile;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"CustomerName: {CustomerName}, \nAddress: {Address}, \nLandmark: {Landmark}, \nCity: {City}, \nCountry: {Country}, \nMobile: {Mobile}";
        }
    }

    public static class CustomerExtensions
    {
        public static CustomerResponse ToCustomerResponse(this Customer customer)
        {
            return new CustomerResponse()
            {
                CustomerID = customer.CustomerID,
                CustomerCode = customer.CustomerCode,
                CustomerName = customer.CustomerName,
                Address = customer.Address,
                Landmark = customer.Landmark,
                City = customer.City,
                Country = customer.Country,
                Mobile = customer.Mobile
            };
        }
    }
}
