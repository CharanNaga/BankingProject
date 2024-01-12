using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Configuration
{
    public static class Settings
    {
        //Initially CustomerCode begins with 1000
        public static long BaseCustomerNumber { get; set; } = 1000;

        public static string UserName { get; set; } = "Admin";
        public static string Password { get; set; } = "Admin123";
    }
}
