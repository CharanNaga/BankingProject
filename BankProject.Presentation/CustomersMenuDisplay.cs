namespace BankProject.Presentation
{
    public class CustomersMenuDisplay
    {
        private readonly CustomersPresentation _customersPresentation;
        public CustomersMenuDisplay(CustomersPresentation customersPresentation)
        {
            _customersPresentation = customersPresentation;
        }
        public void CustomersMenuSelection()
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

        void ManipulateCustomersMenuSelection(int customerMenuChoice)
        {
            switch (customerMenuChoice)
            {
                case 1:
                    _customersPresentation.AddCustomer();
                    break;
                case 2:
                    _customersPresentation.UpdateCustomer();
                    break;
                case 3:
                    _customersPresentation.DisplayCustomers();
                    break;
                case 4:
                    _customersPresentation.FilteredCustomers();
                    break;
                case 5:
                    _customersPresentation.DeleteCustomer();
                    break;
                case 0:
                    break;
            }
        }
    }
}
