using BankProject.Entities;
using BankProject.Exceptions;
using BankProject.ServiceContracts;
using BankProject.ServiceContracts.Dto;

namespace BankProject.Presentation
{
    public class TransactionsPresentation
    {
        private readonly ITransactionsService _transactionsService;
        private readonly IAccountsService _accountsService;
        private readonly AccountsPresentation  _accountsPresentation;

        public TransactionsPresentation(ITransactionsService transactionsService, IAccountsService accountsService, AccountsPresentation accountsPresentation)
        {
            _transactionsService = transactionsService;
            _accountsService = accountsService;
            _accountsPresentation = accountsPresentation;
        }

        public void AddTransaction()
        {
            try
            {
                TransactionAddRequest transactionAddRequest = new TransactionAddRequest();

                _accountsPresentation.DisplayAccounts();

                //source account
                Console.Write("Enter the Source Account Number: ");
                long sourceAccountNumber;
                AccountResponse? sourceAccount;
                while (!long.TryParse(Console.ReadLine(), out sourceAccountNumber))
                {
                    Console.Write("Enter the Source Account Number: ");
                }

                sourceAccount = _accountsService.GetFilteredAccounts(temp => temp.AccountNumber == sourceAccountNumber).FirstOrDefault();
                if (sourceAccount == null)
                {
                    Console.WriteLine("Invalid Account Number.\n");
                    return;
                }

                //destination account
                Console.Write("Enter the Destination Account Number: ");
                long destinationAccountNumber = -1;
                AccountResponse? destinationAccount;
                bool isDestinationAccountNumberValid = false;
                while (!isDestinationAccountNumberValid)
                {
                    while (!long.TryParse(Console.ReadLine(), out destinationAccountNumber))
                    {
                        Console.Write("Enter the Destination Account Number: ");
                    }

                    if (destinationAccountNumber != sourceAccountNumber)
                    {
                        isDestinationAccountNumberValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Source account number and destination account number can't be same");
                    }
                }
                destinationAccount = _accountsService.GetFilteredAccounts(temp => temp.AccountNumber == destinationAccountNumber).FirstOrDefault();
                if (destinationAccount == null)
                {
                    Console.WriteLine("Invalid Account Number.\n");
                    return;
                }


                //date of transaction
                Console.WriteLine("Date of Transaction (YYYY-MM-DD hh:mm:ss tt): ");
                DateTime dateOfTransaction;
                while (!DateTime.TryParse(Console.ReadLine(), out dateOfTransaction))
                {
                    Console.WriteLine("Date of Transaction (YYYY-MM-DD hh:mm:ss tt): ");
                }
                transactionAddRequest.TransactionDateTime = dateOfTransaction;


                //amount
                Console.Write("Amount: ");
                decimal amount;
                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Amount: ");
                }
                transactionAddRequest.Amount = amount;

                //Invoking services
                transactionAddRequest.SourceAccountID = sourceAccount.AccountID;
                transactionAddRequest.DestinationAccountID = destinationAccount.AccountID;

                var transactionResponse = _transactionsService.AddTransaction(transactionAddRequest);
                Console.WriteLine("Transaction Successful...");
                var updatedSourceAccount = _accountsService.GetFilteredAccounts(
                    temp => temp.AccountNumber == sourceAccount.AccountNumber)
                    .FirstOrDefault();

                if(updatedSourceAccount != null)
                {
                    Console.WriteLine($"Account Balance of source account number {updatedSourceAccount.AccountNumber} is: {updatedSourceAccount.Balance}.");
                }


                var updatedDestinationAccount = _accountsService.GetFilteredAccounts(
                    temp => temp.AccountNumber == destinationAccount.AccountNumber)
                    .FirstOrDefault();

                if(updatedDestinationAccount != null)
                {
                    Console.WriteLine($"Account Balance of destination account number {updatedDestinationAccount.AccountNumber} is: {updatedDestinationAccount.Balance}.\n");
                }


            }
            catch (TransactionException ae)
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

        public void DisplayTransactions()
        {
            try
            {
                if (_accountsService.GetAccounts().Count <= 0)
                {
                    Console.WriteLine("No accounts exist");
                    return;
                }

                //display existing accounts
                Console.WriteLine("\n********ACCOUNT STATEMENT*************");
                _accountsPresentation.DisplayAccounts();

                //read all details from the user
                Console.Write("Enter the Account Number that you want to view: ");
                long accountNumberToSearch;
                while (!long.TryParse(Console.ReadLine(), out accountNumberToSearch))
                {
                }
                var existingAccount = _accountsService.GetFilteredAccounts(
                    temp => temp.AccountNumber == accountNumberToSearch)
                    .FirstOrDefault();
                if (existingAccount == null)
                {
                    Console.WriteLine("Invalid Account Number.\n");
                    return;
                }


                Console.WriteLine();
                var debitTransactions = _transactionsService.GetFilteredTransactions(
                    temp => temp.SourceAccountID == existingAccount.AccountID)
                    .OrderBy(temp => temp.TransactionDateTime)
                    .ToList();
                var creditTransactions = _transactionsService.GetFilteredTransactions(
                    temp => temp.DestinationAccountID == existingAccount.AccountID)
                    .OrderBy(temp => temp.TransactionDateTime)
                    .ToList();


                Console.WriteLine("Debit Transactions:");
                if (debitTransactions.Count > 0)
                {
                    Console.WriteLine($"Transaction Date, Source Account Number, Destination Account Number, Transaction Amount");
                    foreach (var transaction in debitTransactions)
                    {
                        var sourceAccount = _accountsService.GetFilteredAccounts(
                            temp => temp.AccountID == transaction.SourceAccountID)
                            .FirstOrDefault();
                        var destinationAccount = _accountsService.GetFilteredAccounts(
                            temp => temp.AccountID == transaction.DestinationAccountID)
                            .FirstOrDefault();

                        if (sourceAccount != null && destinationAccount != null)
                        {
                            Console.WriteLine($"{transaction.TransactionDateTime}, {sourceAccount.AccountNumber}, {destinationAccount.AccountNumber}, {transaction.Amount}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No debit transactions");
                }

                Console.WriteLine("\nCredit Transactions:");
                if (creditTransactions.Count > 0)
                {
                    Console.WriteLine($"Transaction Date, Source Account Number, Destination Account Number, Transaction Amount");
                    foreach (var transaction in creditTransactions)
                    {
                        var sourceAccount = _accountsService.GetFilteredAccounts(
                            temp => temp.AccountID == transaction.SourceAccountID)
                            .FirstOrDefault();
                        var destinationAccount = _accountsService.GetFilteredAccounts(
                            temp => temp.AccountID == transaction.DestinationAccountID)
                            .FirstOrDefault();

                        if (sourceAccount != null && destinationAccount != null)
                        {
                            Console.WriteLine($"{transaction.TransactionDateTime}, {sourceAccount.AccountNumber}, {destinationAccount.AccountNumber}, {transaction.Amount}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No credit transactions");
                }
            }
            catch (TransactionException ae)
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
