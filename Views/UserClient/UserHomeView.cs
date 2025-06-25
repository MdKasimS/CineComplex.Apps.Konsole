using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.Models;
using CineComplex.ViewModels.UserClient;
using Microsoft.IdentityModel.Tokens;


namespace CineComplex.Views.UserClient
{
    public class UserHomeView : AViewBase<UserHomeView>, IView
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
                    "1. Book Ticket",
                    "2. Show Shows",
                    "3. Cancel Tickets",
                    "4. Previous Bookings",
                    "5. Show Profile",
                    "6. Show Balance",
                    "7. Exit ",
                };
            }
        }
        public async Task View()
        {
            Instance.LoadMenuList();

            do//main loop
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
                Console.WriteLine("=================================================");

                Console.WriteLine($"Home - User {Credential.Instance.LoggedInUser.Username,-35}");
                Console.WriteLine("--------------------------------------------------");


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
                        break;
                    case 5:
                        await ProfileView.Instance.View();
                        break;
                    default:
                        Console.WriteLine("Please enter the valid choice .....");
                        break;
                }

                if (Choice == Instance.MenuList.Count)
                {
                    await SignInViewModel.Instance.SignOutCommand();
                }

            } while (Choice != Instance.MenuList.Count);
        }

    }
}
