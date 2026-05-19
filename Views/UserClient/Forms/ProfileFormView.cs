using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.Models;
using Konsole.ViewModels.UserViewModels.FormViewModels;

using Microsoft.IdentityModel.Tokens;

namespace Konsole.Views.UserClient.Forms
{
    public class ProfileFormView : AViewBase<ProfileFormView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList { get; set; }
        public void LoadMenuList()
        {
            if (Instance.MenuList.IsNullOrEmpty())
            {
                Instance.MenuList = new List<string>()
                {
                    " 1. Update User Name",
                    " 2. Update Email",
                    " 3. Update Contact",
                    " 4. Update Pasword",
                    " 5. Add Address",
                    " 6. Add Bank Account",
                    " 7. Update And Save",
                    " 8. Exit"
                };
            }
        }

        public async Task View()
        {
            ProfileFormViewModel.Instance.Init();

            Instance.LoadMenuList();

            do//main loop
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
                Console.WriteLine("================================================");

                Console.WriteLine($"User Profile Form : {Credential.Instance.LoggedInUser.Username,-35}");
                Console.WriteLine("-------------------------------------------------");

                ShowFormData();

                Console.WriteLine();

                Console.WriteLine("\nMenu : ");
                Console.WriteLine("---------------");

                foreach (string instr in Instance.MenuList)
                {
                    Console.WriteLine(instr);
                }

                Console.Write("Enter Your Choice : ");

                int.TryParse(Console.ReadLine(), out _choice);
                switch (Choice)
                {
                    case 1:
                        ProfileFormViewModel.Instance.UserName = Console.ReadLine();
                        break;

                    case 2:
                        ProfileFormViewModel.Instance.Email = Console.ReadLine();
                        break;

                    case 3:
                        ProfileFormViewModel.Instance.Contact = Console.ReadLine();
                        break;

                    case 4:
                        ProfileFormViewModel.Instance.Password = Console.ReadLine();
                        break;

                    case 5:
                        await AddressFormView.Instance.View();
                        break;

                    case 6:
                        await BankAccountFormView.Instance.View();
                        break;

                    case 7:
                        await ProfileFormViewModel.Instance.UpdateAndSaveCommand();
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }

            } while (Choice != Instance.MenuList.Count);
        }

        public void ShowFormData()
        {
            Console.WriteLine($"Entered Name : {ProfileFormViewModel.Instance.UserName}");
            Console.WriteLine($"Entered Email : {ProfileFormViewModel.Instance.Email}");
            Console.WriteLine($"Entered Contact : {ProfileFormViewModel.Instance.Contact}");
            Console.WriteLine($"Entered Password : {ProfileFormViewModel.Instance.Password}");
        }

    }
}
