using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.Views.AdminClient.Forms;

namespace Konsole.Views.AdminClient.ManagerViews
{
    public class ManageCineplexView: AViewBase<ManageCineplexView>, IView
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
            Instance.MenuList = new List<string>() {
                " 1. Register New CineComplex",
                " 2. Show CinComplexes",
                " 3. De-Register A Cineplex",
                " 4. Upate A CineComplex",
                " 5. Update Business GST Number",
                " 6. Update Business A/C Number",
                " 7. Collect Deposit Amount",
                " 8. Print Deposit Receipts",
                " 9. Trasfer Deposit Amount",
                "10. Manage Licenses",
                "11. Exit",

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

                Console.WriteLine("\nManage CineComplex - Admin");
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
                        await RegisterCineplexFormView.Instance.View();
                        Console.Clear();
                        break;

                    case 2:
                        
                        Console.Clear();
                        break;

                    case 3:
                        
                        break;

                    case 4:
                        break;

                    case 5:
                        Console.Clear();
                        break;

                    case 6:
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }
            } while (Choice != Instance.MenuList.Count);
        }
    }
}
