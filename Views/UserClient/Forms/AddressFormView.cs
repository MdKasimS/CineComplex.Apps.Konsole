using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.ViewModels.UserViewModels.FormViewModels;

using Microsoft.IdentityModel.Tokens;

namespace Konsole.Views.UserClient.Forms
{
    public class AddressFormView : AViewBase<AddressFormView>, IView
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
                    " 1. Enter Floor/Building",
                    " 2. Enter Street",
                    " 3. Enter Area",
                    " 4. Enter City",
                    " 5. Enter State",
                    " 6. Enter Country",
                    " 7. Other Details/ Nearby places",
                    " 8. Add Pincode",
                    " 9. Add Address",
                    "10. Reset",
                    "11. Exit"
                };
            }
        }

        public async Task View()
        {
            Instance.LoadMenuList();

            do
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
                Console.WriteLine("================================================");

                Console.WriteLine("\nUser Address - Form");
                Console.WriteLine("-------------------------------------------------");

                AddressFormView.Instance.ShowFormData();
                Console.WriteLine();

                Console.WriteLine("\nMenu : ");
                Console.WriteLine("---------------");

                foreach (string instr in AddressFormView.Instance.MenuList)
                {
                    Console.WriteLine(instr);
                }

                Console.Write("Enter Your Choice : ");

                int.TryParse(Console.ReadLine(), out _choice);
                switch (Choice)
                {
                    case 1:
                        Console.Write("Enter Building Details(Flat No /Floor/ Shop No/ etc.): ");
                        AddressFormViewModel.Instance.BuildingDetails = Console.ReadLine();
                        break;
                    case 2:

                        Console.Write("Enter Street Name/No. : ");
                        AddressFormViewModel.Instance.StreetName = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter Area : ");
                        AddressFormViewModel.Instance.Area = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter City : ");
                        AddressFormViewModel.Instance.City = Console.ReadLine();
                        break;

                    case 5:
                        Console.Write("Enter State : ");
                        AddressFormViewModel.Instance.State = Console.ReadLine();
                        break;

                    case 6:
                        Console.Write("Enter Country : ");
                        AddressFormViewModel.Instance.Country = Console.ReadLine();
                        break;

                    case 7:
                        Console.Write("Enter Near By Spots : ");
                        AddressFormViewModel.Instance.OtherDetails = Console.ReadLine();
                        break;

                    case 8:
                        Console.Write("Enter PinCode : ");
                        AddressFormViewModel.Instance.PinCode = Console.ReadLine();
                        break;

                    case 9:
                        await AddressFormViewModel.Instance.AddAddressCommand();
                        break;

                    case 10:
                        await AddressFormViewModel.Instance.ResetFormCommand();
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }

            } while (Choice != Instance.MenuList.Count);
        }

        public void ShowFormData()
        {
            Console.WriteLine($"Entered BuildingDetails : {AddressFormViewModel.Instance.BuildingDetails}");
            Console.WriteLine($"Entered StreetName : {AddressFormViewModel.Instance.StreetName}");
            Console.WriteLine($"Entered Area : {AddressFormViewModel.Instance.Area}");
            Console.WriteLine($"Entered City : {AddressFormViewModel.Instance.City}");
            Console.WriteLine($"Entered State : {AddressFormViewModel.Instance.State}");
            Console.WriteLine($"Entered Country : {AddressFormViewModel.Instance.Country}");
            Console.WriteLine($"Entered OtherDetails : {AddressFormViewModel.Instance.OtherDetails}");
            Console.WriteLine($"Entered PinCode : {AddressFormViewModel.Instance.PinCode}");
        }

    }
}
