public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*****************************************************************************");
        Console.WriteLine("                     BANKING APPLICATION                                     ");
        Console.WriteLine("*****************************************************************************");
        Console.WriteLine("\n\n---------------------LOGIN PAGE---------------------------------------------");

        //declaring userName & password
        string userName;
        string password;

        Console.Write("Enter User Name: ");
        userName = Console.ReadLine();

        if(!string.IsNullOrEmpty(userName))
        {
            Console.Write("Enter Password: ");
            password = Console.ReadLine();

            if (userName == "Admin" && password == "Admin123")
            {
                int mainMenuChoice = -1;

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
                    mainMenuChoice = Convert.ToInt32(Console.ReadLine());

                    switch (mainMenuChoice)
                    {
                        case 1: //TO DO: Display customers menu
                            break;
                        case 2: //TO DO: Display accounts menu
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
        }
        Console.WriteLine("Thanks!! Exiting the application");
    }
}