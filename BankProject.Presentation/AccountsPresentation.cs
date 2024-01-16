using BankProject.Entities;
using BankProject.Exceptions;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;

namespace BankProject.Presentation
{
    public class AccountsPresentation
    {
        private readonly ICustomersService _customersService;
        private readonly IAccountsService _accountsService;
        private readonly CustomersPresentation _customersPresentation;
        public AccountsPresentation(ICustomersService customersService, IAccountsService accountsService, CustomersPresentation customersPresentation)
        {
            _customersService = customersService;
            _accountsService = accountsService;
            _customersPresentation = customersPresentation;
        }

        public void AddAccount()
        {
            try
            {
                AccountAddRequest accountAddRequest = new AccountAddRequest();

                if (_customersService.GetCustomers().Count <= 0)
                {
                    Console.WriteLine("No customers exist");
                    return;
                }

                //display existing customers
                Console.WriteLine("\n********ADD ACCOUNT*************");
                _customersPresentation.DisplayCustomers();

                //read all details from the user
                Console.Write("Enter the Customer Code for which you want to create a new account: ");
                long customerCodeToEnter;

                while (!long.TryParse(Console.ReadLine(), out customerCodeToEnter))
                {
                    Console.Write("Enter the Customer Code for which you want to create a new account: ");
                }

                var existingCustomer = _customersService.GetFilteredCustomers(temp => temp.CustomerCode == customerCodeToEnter).FirstOrDefault();
                if (existingCustomer == null)
                {
                    Console.WriteLine("Invalid Customer Code.\n");
                    return;
                }
                accountAddRequest.CustomerID = existingCustomer.CustomerID;


                //Invoking corresponding business logic methods
                var addedAccount = _accountsService.AddAccount(accountAddRequest);

                //Display newly generated account number
                var matchingAccounts = _accountsService.GetFilteredAccounts(item => item.AccountID == addedAccount.AccountID);

                if (matchingAccounts.Count >= 1)
                {
                    Console.WriteLine("New Account Number: " + matchingAccounts[0].AccountNumber);
                    Console.WriteLine("Account Added.\n");
                }
                else
                {
                    Console.WriteLine("Account Not added");
                }
            }
            catch(AccountException ae)
            {
                Console.WriteLine(ae.InnerException);
                Console.WriteLine(ae.Message);
                Console.WriteLine(ae.GetType().Name);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        public void DisplayAccounts()
        {
            try
            {
                var accounts = _accountsService.GetAccounts();
                if(accounts.Count == 0)
                {
                    Console.WriteLine("No accounts are present in database.\n");
                    return;
                }
            
                Console.WriteLine("\n**********ALL ACCOUNTS*************");

                //reading all accounts
                foreach (var account in accounts)
                {
                    Console.WriteLine("Account Number: " + account.AccountNumber);

                    //Get customer details based on CustomerID of account
                    var customer = _customersService.GetFilteredCustomers(temp => temp.CustomerID == account.CustomerID).FirstOrDefault();
                    if (customer != null)
                    {
                        Console.WriteLine("Customer Code: " + customer.CustomerCode);
                        Console.WriteLine("Customer Name: " + customer.CustomerName);
                    }

                    Console.WriteLine("Balance: " + account.Balance);
                    Console.WriteLine();
                }
            }
            catch (AccountException ae)
            {
                Console.WriteLine(ae.InnerException);
                Console.WriteLine(ae.Message);
                Console.WriteLine(ae.GetType().Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        public void UpdateAccount()
        {
            try
            {
                if (_accountsService.GetAccounts().Count <= 0)
                {
                    Console.WriteLine("No accounts exist");
                    return;
                }

                //display existing accounts
                Console.WriteLine("\n********EDIT ACCOUNT*************");
                DisplayAccounts();

                //read all details from the user

                Console.Write("Enter the Account Number that you want to edit: ");
                long accountCodeToEdit;

                while (!long.TryParse(Console.ReadLine(), out accountCodeToEdit))
                {
                    Console.Write("Enter the Account Number that you want to edit: ");
                }

                var existingAccount = _accountsService.GetFilteredAccounts(temp => temp.AccountNumber == accountCodeToEdit).FirstOrDefault();
                if (existingAccount == null)
                {
                    Console.WriteLine("Invalid Account Number.\n");
                    return;
                }

                Console.WriteLine();
                _customersPresentation.DisplayCustomers();

                //read all details from the user
                Console.Write("Enter the Updated (existing) Customer Code: ");
                long customerCodeToEdit;

                while (!long.TryParse(Console.ReadLine(), out customerCodeToEdit))
                {
                    Console.Write("Enter the Updated (existing) Customer Code: ");
                }

                var existingCustomer = _customersService.GetFilteredCustomers(temp => temp.CustomerCode == customerCodeToEdit).FirstOrDefault();
                if (existingCustomer == null)
                {
                    Console.WriteLine("Invalid Customer Code.\n");
                    return;
                }
                existingAccount.CustomerID = existingCustomer.CustomerID;


                Console.Write("Balance: ");
                existingAccount.Balance = long.Parse(Console.ReadLine());

                var existingAccountRequest = existingAccount.ToAccountUpdateRequest();

                var updatedAccount = _accountsService.UpdateAccount(existingAccountRequest);

                if (updatedAccount == null)
                {
                    Console.WriteLine("Account Updation failed");
                    return;
                }
                Console.WriteLine("Account updated successfully");
            }
            catch (AccountException ae)
            {
                Console.WriteLine(ae.InnerException);
                Console.WriteLine(ae.Message);
                Console.WriteLine(ae.GetType().Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        public void FilteredAccounts()
        {
            try
            {
                if (_accountsService.GetAccounts().Count <= 0)
                {
                    Console.WriteLine("No accounts exist");
                    return;
                }

                //display existing accounts
                Console.WriteLine("\n********FILTER ACCOUNTS*************");
                DisplayAccounts();

                Console.Write("Enter the Account Number that you want to get: ");
                long accountCodeToEdit;
                while (!long.TryParse(Console.ReadLine(), out accountCodeToEdit))
                {
                    Console.Write("Enter the Account Number that you want to get: ");
                }
                var existingAccount = _accountsService.GetFilteredAccounts(temp => temp.AccountNumber == accountCodeToEdit).FirstOrDefault();
                if (existingAccount == null)
                {
                    Console.WriteLine("Invalid Account Number.\n");
                    return;
                }
                Console.WriteLine("Account Number: " + existingAccount.AccountNumber);

                //Get customer details based on CustomerID of account
                var existingCustomer = _customersService.GetFilteredCustomers(temp => temp.CustomerID == existingAccount.CustomerID).FirstOrDefault();
                if (existingCustomer != null)
                {
                    Console.WriteLine("Customer Code: " + existingCustomer.CustomerCode);
                    Console.WriteLine("Customer Name: " + existingCustomer.CustomerName);
                }

                Console.WriteLine("Balance: " + existingAccount.Balance);
                Console.WriteLine();
            }
            catch (AccountException ae)
            {
                Console.WriteLine(ae.InnerException);
                Console.WriteLine(ae.Message);
                Console.WriteLine(ae.GetType().Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }


    }
}
