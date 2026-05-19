using CineComplex.Models;

using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.ViewModels.AdminViewModels.FormsViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Views.AdminClient.Forms
{
    public class ForgotPasswordFormView : AViewBase<ForgotPasswordFormView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList
        {
            get;
            set;
        }
        public void LoadMenuList()
        {
            ForgotPasswordFormView.Instance.MenuList = new List<string>() {
                "1. Enter User Id ",
                "2. Enter Email  ",
                "3. Enter Contact ",
                "4. Set New Password ",
                "5. Exit",
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

                Console.WriteLine($"Admin Forgot Password : Enter Any Of The Detail");
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
                        Console.Write("Enter User Name: ");
                        ForgotPasswordFormViewModel.Instance.UserName = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter Email: ");
                        ForgotPasswordFormViewModel.Instance.Email = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter Contact: ");
                        ForgotPasswordFormViewModel.Instance.Contact = Console.ReadLine();
                        break;
                    case 4:
                        SetNewPasswordFormView();
                        break;
                }
                
            } while (Choice != Instance.MenuList.Count);
        }
        
        private void SetNewPasswordFormView()
        {
            //Whose VM is not avaialable or isn't of worth creating, how to handle its queries

            Console.Clear();
            Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
            Console.WriteLine("================================================");

            Console.WriteLine($"Forgot Password : Set New Password");
            Console.WriteLine("-------------------------------------------------");


            Console.WriteLine();

            Console.WriteLine("\nEnter New Password: ");
            ForgotPasswordFormViewModel.Instance.Password = Console.ReadLine();

        }
    }
}
