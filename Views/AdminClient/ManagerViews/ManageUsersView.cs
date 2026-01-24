using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.Models;
using CineComplex.Views.UserClient.Forms;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.Views.AdminClient.ManagerViews
{
    class ManageUsersView : AViewBase<ManageUsersView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList { get; set; }
        public void LoadMenuList()
        {
            //Command operations
            Instance.MenuList = new List<string>()
            {
                "1. Show Users",
                "2. Create User",
                "3. Update User",
                "4. Activate User",
                "5. Deactivate User",
                "6. Delete User",
                "7. Exit",
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

                Console.WriteLine("\nManage Users - Admin");
                Console.WriteLine("-------------------------------------------------");

                Console.WriteLine();

                Console.WriteLine("\nMenu : ");
                Console.WriteLine("---------------");

                foreach (string instr in AdminClient.ManagerViews.ManageUsersView.Instance.MenuList)
                {
                    Console.WriteLine(instr);
                }

                Console.Write("Enter Your Choice : ");

                int.TryParse(Console.ReadLine(), out _choice);
                switch (Choice)
                {
                    case 1:
                        Instance.DisplayAllUsers();
                        break;
                    case 2:
                        await SignUpFormView.Instance.View();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }


            } while (Choice != AdminClient.ManagerViews.ManageUsersView.Instance.MenuList.Count);
        }

        public void DisplayAllUsers()
        {

        }
    }
}
