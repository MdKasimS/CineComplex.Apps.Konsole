using CineComplex.Models;

using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.ViewModels.UserViewModels.FormViewModels;

using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Views.CineplexClient.Forms
{
    class BankAccountFormView : AViewBase<BankAccountFormView>, IView
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
                    "1. Enter Account Holder Name",
                    "2. Enter AccountNumber",
                    "3. Enter GSTNumber",
                    "4. Enter Bank Name",
                    "5. Enter IFSCNumber",
                    "6. Add Bank Account",
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

                Console.WriteLine("\nAdd Bank Account - Form");
                Console.WriteLine("-------------------------------------------------");

                BankAccountFormView.Instance.ShowFormData();
                Console.WriteLine();

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
                        Console.Write("Enter Account Holder Name : ");
                        BankAccountFormViewModel.Instance.AccountHolderName = Console.ReadLine();
                        break;
                    
                    case 2:
                        Console.Write("Enter Account Number : ");
                        BankAccountFormViewModel.Instance.AccountNumber = Console.ReadLine(); 
                        
                        break;
                    
                    case 3:
                        Console.Write("Enter GST Number : ");
                        BankAccountFormViewModel.Instance.GSTNumber = Console.ReadLine();

                        break;
                    
                    case 4:
                        Console.Write("Enter Bank Name : ");
                        BankAccountFormViewModel.Instance.BankName = Console.ReadLine();

                        break;
                    
                    case 5:
                        Console.Write("Enter IFSC Number : ");
                        BankAccountFormViewModel.Instance.IFSCNumber = Console.ReadLine();
                        break;
                    
                    case 6:
                        await BankAccountFormViewModel.Instance.AddBankAccountCommand();
                        break;

                    default:
                        Console.WriteLine("Please enter the valid choice .....");
                        break;
                }

            } while (Choice != Instance.MenuList.Count);
        }

        public void ShowFormData()
        {
            Console.WriteLine($"Entered Account Name : {BankAccountFormViewModel.Instance.AccountHolderName}");
            Console.WriteLine($"Entered AccountNumber : {BankAccountFormViewModel.Instance.AccountNumber}");
            Console.WriteLine($"Entered GSTNumber : {BankAccountFormViewModel.Instance.GSTNumber}");
            Console.WriteLine($"Entered BankName : {BankAccountFormViewModel.Instance.BankName}");
            Console.WriteLine($"Entered IFSCNumber : {BankAccountFormViewModel.Instance.IFSCNumber}");
        }
    }
}
