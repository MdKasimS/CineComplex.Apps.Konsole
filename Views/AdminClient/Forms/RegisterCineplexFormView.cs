using Konsole.Views.AdminClient.ManagerViews;
using Konsole.Interfaces;
using Konsole.ViewModels.AdminViewModels;
using Konsole.ViewModels.AdminViewModels.FormsViewModels;
using Konsole.Classes.Base;

namespace Konsole.Views.AdminClient.Forms
{
    public class RegisterCineplexFormView : AViewBase<RegisterCineplexFormView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList { get; set; }

        public void LoadMenuList()
        {
            Instance.MenuList = new List<string>()
            {
                "1. Step 1. Enter Company Name",
                "2. Step 2. Add Address ",
                "3. Step 3. Add Bank Details",
                "4. Step 4. Create User",
                "5. Step 5. Enter Password",
                "6. Step 6. Register Cineplex",
                "7. Reset",
                "8. Exit"
            };
        }

        public async Task View()
        {

            Instance.LoadMenuList();

            do
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
                Console.WriteLine("================================================");

                Console.WriteLine("\nRegister For CinemaComplex - Form");
                Console.WriteLine("-------------------------------------------------");

                RegisterCineplexFormView.Instance.ShowFormData();
                Console.WriteLine();

                Console.WriteLine("\nMenu : ");
                Console.WriteLine("---------------");

                foreach (string step in Instance.MenuList)
                {
                    Console.WriteLine(step);
                }


                //AddressFormView.Instance.View();
                Console.Write("Enter Your Choice : ");

                int.TryParse(Console.ReadLine(), out _choice);
                switch (Choice)
                {
                    case 1:
                        await SignUpFormView.Instance.View();
                        break;

                    case 2:
                        //Manage show view
                        break;

                    case 3:
                        //Manage User view
                        await ManageUsersView.Instance.View();
                        break;

                    case 7:
                        ManageCineplexView.Instance.View();
                        break;

                    case 6:
                        AdminHomeViewModel.Instance.SignOut();
                        SignInViewModel.Instance.ResetFormCommand();
                        HomeView.Instance.View();
                        break;
                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }
            } while (Choice != Instance.MenuList.Count);

        }

        public void ShowFormData()
        {
            Console.WriteLine($"Step 1 : {RegisterCineplexFormViewModel.Instance.IsStep1}");
            Console.WriteLine($"Step 2 : {RegisterCineplexFormViewModel.Instance.IsStep2}");
            Console.WriteLine($"Step 3 : {RegisterCineplexFormViewModel.Instance.IsStep3}");
            Console.WriteLine($"Step 4 : {RegisterCineplexFormViewModel.Instance.IsStep4}");
            Console.WriteLine($"Step 5 : {RegisterCineplexFormViewModel.Instance.IsStep5}");
            Console.WriteLine($"Step 6 : {RegisterCineplexFormViewModel.Instance.IsStep6}");
        }
    }
}
