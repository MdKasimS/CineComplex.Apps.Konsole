using CineComplex.Classes.Base;
using CineComplex.Interfaces;

namespace CineComplex.Views
{
    public class StartView : AViewBase<StartView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList
        {
            get;
            set;
        }

        /// <summary>
        /// This will be shown to all kinds of users - user/admin/partner
        /// </summary>
        public void LoadMenuList()
        {
            StartView.Instance.MenuList = new List<string>() {
                "1. Login",
                "2. Forgot Password",
                "3. Contact Us",
                "4. Careers",
                "5. Exit",
            };
        }

        /// <summary>
        /// This will be shown to all kinds of users - user/admin/partner
        /// </summary>
        public async Task View()
        {
            StartView.Instance.LoadMenuList();

            do//main loop
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
                Console.WriteLine("================================================");

                Console.WriteLine("\nStart - CineComplex");
                Console.WriteLine("-------------------------------------------------");

                Console.WriteLine();

                Console.WriteLine("\nMenu : ");
                Console.WriteLine("---------------");

                foreach (string instr in StartView.Instance.MenuList)
                {
                    Console.WriteLine(instr);
                }

                Console.Write("Enter Your Choice : ");


                int.TryParse(Console.ReadLine(), out _choice);
                switch (Choice)
                {
                    case 1:
                        await HomeView.Instance.View();
                        break;

                    case 2:
                        //ForgotPasswordFormView.Instance.View();
                        break;

                    case 3:
                        //Contact Us
                        break;

                    case 4:
                        //Careers
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }
            } while (Choice != StartView.Instance.MenuList.Count);
        }
    }
}
