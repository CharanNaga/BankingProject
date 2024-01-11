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
                Console.WriteLine("______________________MAIN MENU__________________________________________");

            }
        }

        Console.WriteLine("Thanks!! Exiting");
        
    }
}