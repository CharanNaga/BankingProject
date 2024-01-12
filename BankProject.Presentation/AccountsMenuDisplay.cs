namespace BankProject.Presentation
{
    public static class AccountsMenuDisplay
    {
        public static void AccountsMenuSelection()
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

                accountMenuChoice = MainMenuDisplay.GetChoice("Enter your choice [0-5]: ", accountMenuChoice);
                ManipulateAccountsMenuSelection(accountMenuChoice);

            } while (accountMenuChoice != 0);
        }

        static void ManipulateAccountsMenuSelection(int accountMenuChoice)
        {
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
        }
    }
}
