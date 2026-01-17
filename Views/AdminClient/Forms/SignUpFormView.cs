using CineComplex.Classes;
using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.ViewModels.AdminViewModels.FormViewModels;
using CineComplex.ViewModels.FormViewModels;


namespace CineComplex.Views.AdminClient.Forms
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
                "7. Exit"
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

                Console.WriteLine("\nSign Up Form - Admin");
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

                        Result<bool> result = await SignUpFormViewModel.Instance.CreateUserCommand();
                        Console.Write(result.Message);
                        Console.ReadKey();

                        if (result.IsSuccessful)
                        {
                            //SignUpFormViewModel.Instance.ResetFormCommand();
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
