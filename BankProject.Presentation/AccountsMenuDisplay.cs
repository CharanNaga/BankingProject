namespace BankProject.Presentation
{
    public class AccountsMenuDisplay
    {
        private readonly AccountsPresentation _presentation;

        public AccountsMenuDisplay(AccountsPresentation presentation)
        {
            _presentation = presentation;
        }


        public void AccountsMenuSelection()
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

        void ManipulateAccountsMenuSelection(int accountMenuChoice)
        {
            switch (accountMenuChoice)
            {
                case 1:
                    _presentation.AddAccount();
                    break;
                case 2:
                    _presentation.UpdateAccount();
                    break;
                case 3:
                    _presentation.DisplayAccounts();
                    break;
                case 4: 
                    _presentation.FilteredAccounts();
                    break;
                case 5:
                    _presentation.DeleteAccount();
                    break;
                case 0:
                    break;
            }
        }
    }
}