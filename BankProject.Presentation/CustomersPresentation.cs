﻿using BankProject.Entities;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;
using BankProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Presentation
{
    public static class CustomersPresentation
    {
        private static readonly ICustomersService _customersService;

        static CustomersPresentation()
        {
            _customersService = new CustomersService(); 
        }

        public static void AddCustomer()
        {
            CustomerAddRequest customerAddRequest = new CustomerAddRequest();

            //read details from user
            Console.WriteLine("\n*****************************ADD CUSTOMER**********************************");

            Console.Write("Customer Name: ");
            customerAddRequest.CustomerName = Console.ReadLine();

            Console.Write("Address: ");
            customerAddRequest.Address = Console.ReadLine();

            Console.Write("Landmark: ");
            customerAddRequest.Landmark = Console.ReadLine();

            Console.Write("City: ");
            customerAddRequest.City = Console.ReadLine();

            Console.Write("Country: ");
            customerAddRequest.Country = Console.ReadLine();

            Console.Write("Mobile: ");
            customerAddRequest.Mobile = Console.ReadLine();

            //invoking business layer methods
            var addedCustomer = _customersService.AddCustomer(customerAddRequest);

            var matchingCustomers =  _customersService.GetFilteredCustomers(c => c.CustomerID == addedCustomer.CustomerID);

            if (matchingCustomers.Count >= 1)
            {
                Console.WriteLine("New Customer Code: " + matchingCustomers[0].CustomerCode);
                Console.WriteLine("Customer Added.\n");
            }
            else
            {
                Console.WriteLine("Customer Not added");
            }
        }

        public static void DisplayCustomers()
        {
            var customers = _customersService.GetCustomers();
            if(customers.Count == 0)
            {
                Console.WriteLine("No customers are present in database.\n");
                return;
            }
            //read all customers
            Console.WriteLine("\n**********ALL CUSTOMERS*************");

            foreach (var customer in customers)
            {
                Console.WriteLine("Customer Code: " + customer.CustomerCode);
                Console.WriteLine("Customer Name: " + customer.CustomerName);
                Console.WriteLine("Address: " + customer.Address);
                Console.WriteLine("Landmark: " + customer.Landmark);
                Console.WriteLine("City: " + customer.City);
                Console.WriteLine("Country: " + customer.Country);
                Console.WriteLine("Mobile: " + customer.Mobile);
                Console.WriteLine();
            }
        }
    }
}
