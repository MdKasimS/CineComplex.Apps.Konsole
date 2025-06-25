using CineComplex.Classes;
using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.Models;
using CineComplex.Views.AdminClient.Forms;
using CineComplex.ViewModels.AdminViewModels;

namespace CineComplex.Views.AdminClient
{
    public class SignInView : AViewBase<SignInView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }

        public List<string> MenuList
        {
            get;
            set;
        }
        public async Task View()
        {
            SignInView.Instance.LoadMenuList();

            do//main loop
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
                Console.WriteLine("================================================");

                Console.WriteLine("\nSignIn View - Admin");
                Console.WriteLine("-------------------------------------------------");

                Console.WriteLine($"Entered Login Id : {Credential.Instance.LoginId}");
                Console.WriteLine($"Entered Password : {Credential.Instance.Password}");

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
                        Console.Write("Enter LoginID : ");
                        SignInViewModel.Instance.GetSignInId();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Write("Enter Password : ");
                        SignInViewModel.Instance.GetSignIPassword();
                        Console.Clear();
                        break;

                    case 3:
                        await SignInViewModel.Instance.SignInCommand();
                        if (SignInViewModel.Instance.AuthenticationResult.IsSuccessful && Credential.Instance.UserSession.Token != null)
                        {
                            await AdminHomeView.Instance.View();
                        }
                        else
                        {
                            Console.Write($"{SignInViewModel.Instance.AuthenticationResult.Message}" );
                            Console.ReadLine();
                        }
                        break;

                    case 4:
                        await SignUpFormView.Instance.View();
                        break;

                    case 5:
                        await ForgotPasswordFormView.Instance.View();
                        Console.Clear();
                        break;

                    case 6:
                        SignInViewModel.Instance.ResetFormCommand();
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }
            } while (Choice != Instance.MenuList.Count);
        }

        public void LoadMenuList()
        {
            Instance.MenuList = new List<string>() {
                "1. Enter Login Id ",
                "2. Enter Password ",
                "3. Login ",
                "4. Sign Up ",
                "5. Forgot Password ",
                "6. Reset Form ",
                "7. Exit",
            };
        }
    }
}
