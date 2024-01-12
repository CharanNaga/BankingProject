using BankProject.Configuration;

namespace BankProject.Presentation
{
    public static class MainMenuDisplay
    {
        public static void DisplayMenu()
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

        static int MainMenuSelection()
        {
            int mainMenuChoice = -1;
            Console.WriteLine("______________________MAIN MENU__________________________________________");
            Console.WriteLine("1. Customers");
            Console.WriteLine("2. Accounts");
            Console.WriteLine("3. Funds Transfer");
            Console.WriteLine("4. Funds Transfer Statement");
            Console.WriteLine("5. Account Statement");
            Console.WriteLine("0. Exit");

            mainMenuChoice = GetChoice("Enter your choice [0-5]: ", mainMenuChoice);
            ManipulateMainMenuSelection(mainMenuChoice);
            return mainMenuChoice;
        }

        static void ManipulateMainMenuSelection(int mainMenuChoice)
        {
            switch (mainMenuChoice)
            {
                case 1:
                    CustomersMenuDisplay.CustomersMenuSelection();
                    break;
                case 2:
                    AccountsMenuDisplay.AccountsMenuSelection();
                    break;
                case 3: //TO DO: Display funds transfer menu
                    break;
                case 4: //TO DO: Display funds transfer statement menu
                    break;
                case 5: //TO DO: Display account statement menu
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
    }
}