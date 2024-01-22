using BankProject.Configuration;

namespace BankProject.Presentation
{
    public class MainMenuDisplay
    {
        private readonly CustomersMenuDisplay _customersDisplay;
        private readonly AccountsMenuDisplay _accountsDisplay;
        private readonly TransactionsPresentation _transactionsPresentation;

        public MainMenuDisplay(CustomersMenuDisplay customersMenuDisplay, AccountsMenuDisplay accountsDisplay, TransactionsPresentation transactionsPresentation)
        {
            _customersDisplay = customersMenuDisplay;
            _accountsDisplay = accountsDisplay;
            _transactionsPresentation = transactionsPresentation;
        }

        public async Task RunAsync()
        {
            DisplayMenu();
        }
        public void DisplayMenu()
        {
            Console.WriteLine("*****************************************************************************");
            Console.WriteLine("                     BANKING APPLICATION                                     ");
            Console.WriteLine("*****************************************************************************");
            Console.WriteLine("\n\n---------------------LOGIN PAGE---------------------------------------------");

            //declaring userName & password
            string? userName = null, password = null;

            while (true)
            {
                userName = GetInput("Enter User Name: ");

                if (!string.IsNullOrEmpty(userName))
                {
                    password = GetInput("Enter Password: ");
                }
                else
                {
                    break;
                }

                int mainMenuChoice = -1;

                if (userName == Settings.UserName && password == Settings.Password)
                {
                    do
                    {
                       mainMenuChoice = MainMenuSelection();
                    } while (mainMenuChoice != 0);
                }

                else
                {
                    Console.WriteLine("Invalid UserName or Password");
                }

                if (mainMenuChoice == 0)
                    break;
            }

            Console.WriteLine("Thanks for your time!! Exiting the application");
        }

        int MainMenuSelection()
        {
            int mainMenuChoice = -1;
            Console.WriteLine("______________________MAIN MENU__________________________________________");
            Console.WriteLine("1. Customers");
            Console.WriteLine("2. Accounts");
            Console.WriteLine("3. Funds Transfer Statement");
            Console.WriteLine("4. Account Statement");
            Console.WriteLine("0. Exit");

            mainMenuChoice = GetMainMenuChoice("Enter your choice [0-4]: ", mainMenuChoice);
            ManipulateMainMenuSelection(mainMenuChoice);
            return mainMenuChoice;
        }

        void ManipulateMainMenuSelection(int mainMenuChoice)
        {
            switch (mainMenuChoice)
            {
                case 1:
                    _customersDisplay.CustomersMenuSelection();
                    break;
                case 2:
                    _accountsDisplay.AccountsMenuSelection();
                    break;
                case 3:
                    _transactionsPresentation.AddTransaction();
                    break;
                case 4:
                    _transactionsPresentation.DisplayTransactions();
                    break;
                case 0:
                    break;
            }
        }

        static string GetInput(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        public static int GetChoice(string input, int value)
        {
            Console.Write("Enter your choice [0-5]: ");
            while (!int.TryParse(Console.ReadLine(), out value) || (value < 0 || value > 5))
            {
                Console.WriteLine("Invalid Choice");
                Console.Write("Enter your choice [0-5]: ");
            }
            return value;
        }

        private static int GetMainMenuChoice(string input, int value)
        {
            Console.Write("Enter your choice [0-4]: ");
            while (!int.TryParse(Console.ReadLine(), out value) || (value < 0 || value > 4))
            {
                Console.WriteLine("Invalid Choice");
                Console.Write("Enter your choice [0-4]: ");
            }
            return value;
        }
    }
}