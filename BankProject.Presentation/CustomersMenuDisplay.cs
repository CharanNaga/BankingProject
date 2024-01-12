namespace BankProject.Presentation
{
    public static class CustomersMenuDisplay
    {
        public static void CustomersMenuSelection()
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

                customerMenuChoice = MainMenuDisplay.GetChoice("Enter your choice [0-5]: ", customerMenuChoice);
                ManipulateCustomersMenuSelection(customerMenuChoice);
            } while (customerMenuChoice != 0);
        }

        static void ManipulateCustomersMenuSelection(int customerMenuChoice)
        {
            switch (customerMenuChoice)
            {
                case 1:
                    CustomersPresentation.AddCustomer();
                    break;
                case 2:
                    CustomersPresentation.UpdateCustomer();
                    break;
                case 3:
                    CustomersPresentation.DisplayCustomers();
                    break;
                case 4:
                    CustomersPresentation.FilteredCustomers();
                    break;
                case 5:
                    CustomersPresentation.DeleteCustomer();
                    break;
                case 0:
                    break;
            }
        }
    }
}
