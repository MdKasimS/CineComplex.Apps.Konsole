using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.ViewModels.CineplexViewModels.FormsViewModels;

namespace Konsole.Views.CineplexClient.Forms
{
    public class SignUpFormView : AViewBase<SignUpFormView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList { get; set; }

        public void LoadMenuList()
        {
            Instance.MenuList = new List<string>()
            {
                "1. Enter Name",
                "2. Enter Email",
                "3. Enter Contact",
                "4. Enter Password",
                "5. Sign Up",
                "6. Reset",
                "7. Next",
                "8. Cancel"
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

                Console.WriteLine("\nSign Up Form - CineComplex");
                Console.WriteLine("-------------------------------------------------");

                SignUpFormView.Instance.ShowFormData();
                Console.WriteLine();

                Console.WriteLine("\nMenu : ");
                Console.WriteLine("---------------");

                foreach (string instr in SignUpFormView.Instance.MenuList)
                {
                    Console.WriteLine(instr);
                }

                Console.Write("Enter Your Choice : ");

                int.TryParse(Console.ReadLine(), out _choice);
                switch (Choice)
                {
                    case 1:
                        Console.Write("Enter User Name: ");
                        SignUpFormViewModel.Instance.UserName = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter Email: ");
                        SignUpFormViewModel.Instance.Email = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter Contact: ");
                        SignUpFormViewModel.Instance.Contact = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter Password: ");
                        SignUpFormViewModel.Instance.Password = Console.ReadLine();
                        break;

                    case 5:

                        SignUpFormViewModel.Instance.CreateUserCommand().Wait();
                        Console.Write(SignUpFormViewModel.Instance.SignUpResult.Message);
                        Console.ReadKey();

                        if (SignUpFormViewModel.Instance.SignUpResult.IsSuccessful)
                        {
                            SignUpFormViewModel.Instance.ResetFormCommand();
                            return;
                        }

                        break;

                    case 6:
                        SignUpFormViewModel.Instance.ResetFormCommand();
                        break;

                    case 7:
                        SignUpFormViewModel.Instance.ResetFormCommand();
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }


            } while (Choice != Instance.MenuList.Count);
        }

        public void ShowFormData()
        {
            Console.WriteLine($"Entered Name : {SignUpFormViewModel.Instance.UserName}");
            Console.WriteLine($"Entered Email : {SignUpFormViewModel.Instance.Email}");
            Console.WriteLine($"Entered Contact : {SignUpFormViewModel.Instance.Contact}");
            Console.WriteLine($"Entered Password : {SignUpFormViewModel.Instance.Password}");
        }
    }
}
