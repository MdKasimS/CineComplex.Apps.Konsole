using Konsole.Classes.Base;
using Konsole.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Views
{
    public class HomeView : AViewBase<HomeView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList
        {
            get;
            set;
        }

        /// <summary>
        /// This is for user to select which type of login they want to perform
        /// </summary>
        public void LoadMenuList()
        {
            HomeView.Instance.MenuList = new List<string>() {
                "1. User Login ",
                "2. Admin Login ",
                "3. CineComplex Login ",
                "4. Exit",
            };
        }

        /// <summary>
        /// This is for user to select which type of login they want to perform
        /// </summary>
        public async Task View()
        {
            HomeView.Instance.LoadMenuList();

            do//main loop
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
                Console.WriteLine("================================================");

                Console.WriteLine("\nHome - CineComplex Monlithic Application");
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
                        //User SignIn View
                        await UserClient.SignInView.Instance.View();
                        break;

                    case 2:
                        //Admin SignIn View
                        await AdminClient.SignInView.Instance.View();
                        break;

                    case 3:
                        //Theatre Owner SignIn View
                        await CineplexClient.SignInView.Instance.View();
                        break;


                    default:
                        Console.WriteLine("Please enter the valid Choice 2 .....");
                        break;
                }
            } while (Choice != Instance.MenuList.Count);
        }

    }
}
