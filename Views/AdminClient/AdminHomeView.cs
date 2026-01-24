using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.ViewModels;
using CineComplex.ViewModels.AdminViewModels;
using CineComplex.Views.AdminClient.ManagerViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.Views.AdminClient
{
    public class AdminHomeView : AViewBase<AdminHomeView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList { get; set; }
        public void LoadMenuList()
        {
            //TODO: Please added check for loading list again and again like in UserClient
            Instance.MenuList = new List<string>() {
                "1. See Shows",
                "2. Manage Shows",
                "3. Manage Users",
                "4. Manage Admins",
                "5. Manage Tickets",
                "6. Manage Movies",
                "7. Manage CineComplexes",
                "8. Exit",
            };
        }

        public async Task View()
        {
            Instance.LoadMenuList();

            do//main loop
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
                Console.WriteLine("================================================");

                Console.WriteLine("\nHome - Admin");
                Console.WriteLine("-------------------------------------------------");

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
                        //Show all shows
                        break;

                    case 2:
                        //Manage show view
                        break;

                    case 3:
                        //Manage User view
                        await ManageUsersView.Instance.View();
                        break;

                    case 7:
                        await ManageCineplexView.Instance.View();
                        break;

                    case 8:
                        AdminHomeViewModel.Instance.SignOut();
                        SignInViewModel.Instance.ResetFormCommand();
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }
            } while (Choice != Instance.MenuList.Count);
        }

    }

}
