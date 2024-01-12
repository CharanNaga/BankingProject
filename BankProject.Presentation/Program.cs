using BankProject.Presentation;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*****************************************************************************");
        Console.WriteLine("                     BANKING APPLICATION                                     ");
        Console.WriteLine("*****************************************************************************");
        Console.WriteLine("\n\n---------------------LOGIN PAGE---------------------------------------------");

        //declaring userName & password
        string? userName = null, password = null;

        while (true)
        {
            Console.Write("Enter User Name: ");
            userName = Console.ReadLine();

            if (!string.IsNullOrEmpty(userName))
            {
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
            }
            else
            {
                break;
            }

            int mainMenuChoice = -1;

            if (userName == "Admin" && password == "Admin123")
            {

                do
                {
                    Console.WriteLine("______________________MAIN MENU__________________________________________");
                    Console.WriteLine("1. Customers");
                    Console.WriteLine("2. Accounts");
                    Console.WriteLine("3. Funds Transfer");
                    Console.WriteLine("4. Funds Transfer Statement");
                    Console.WriteLine("5. Account Statement");
                    Console.WriteLine("0. Exit");

                    Console.Write("Enter your choice [0-5]: ");
                    while (!int.TryParse(Console.ReadLine(), out mainMenuChoice) || (mainMenuChoice < 0 || mainMenuChoice > 5))
                    {
                        Console.Write("Invalid Choice.\nEnter your choice [0-5]: ");
                    }

                    switch (mainMenuChoice)
                    {
                        case 1:
                            CustomersMenu();
                            break;
                        case 2:
                            AccountsMenu();
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

    static void CustomersMenu()
    {
        int customerMenuChoice = -1;
        do
        {
            Console.WriteLine("______________________CUSTOMER MENU__________________________________________");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Update Customer");
            Console.WriteLine("3. Fetch Customers");
            Console.WriteLine("4. Filter Customers");
            Console.WriteLine("5. Delete Customer");
            Console.WriteLine("0. Back to Main Menu");

            Console.Write("Enter your choice [0-5]: ");
            while (!int.TryParse(Console.ReadLine(), out customerMenuChoice) || (customerMenuChoice < 0 || customerMenuChoice > 5))
            {
                Console.Write("Invalid Choice.\nEnter your choice [0-5]: ");
            }

            switch (customerMenuChoice)
            {
                case 1: CustomersPresentation.AddCustomer();
                    break;
                case 2: CustomersPresentation.UpdateCustomer();
                    break;
                case 3: CustomersPresentation.DisplayCustomers();
                    break;
                case 4: CustomersPresentation.FilteredCustomers();
                    break;
                case 5: CustomersPresentation.DeleteCustomer();
                    break;
                case 0:
                    break;
            }
        } while (customerMenuChoice != 0);
    }


    static void AccountsMenu()
    {
        int accountMenuChoice = -1;
        do
        {
            Console.WriteLine("______________________ACCOUNT MENU__________________________________________");
            Console.WriteLine("1. Add Account");
            Console.WriteLine("2. Update Account");
            Console.WriteLine("3. Fetch Accounts");
            Console.WriteLine("4. Filter Accounts");
            Console.WriteLine("5. Delete Account");
            Console.WriteLine("0. Back to Main Menu");

            Console.Write("Enter your choice [0-5]: ");
            while (!int.TryParse(Console.ReadLine(), out accountMenuChoice) || (accountMenuChoice < 0 || accountMenuChoice > 5))
            {
                Console.Write("Invalid Choice.\nEnter your choice [0-5]: ");
            }

            switch (accountMenuChoice)
            {
                case 1: //TO DO: Create Account
                    break;
                case 2: //TO DO: Update Account
                    break;
                case 3: //TO DO: Get all Accounts
                    break;
                case 4: //TO DO: Get Account by AccountID
                    break;
                case 5: //TO DO: Delete Account
                    break;
                case 0:
                    break;
            }
        } while (accountMenuChoice != 0);
    }
}