using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.Views.CineplexClient.ManagerViews;

namespace Konsole.Views.CineplexClient
{
    public class CineplexHomeView : AViewBase<CineplexHomeView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList { get; set; }
        public void LoadMenuList()
        {
            //TODO: Please added check for loading list again and again like in UserClient
            Instance.MenuList = new List<string>() {
                "1. Show Scheduled Shows",
                "2. Manage Shows",
                "3. Manage Tickets",
                "4. Manage Theatres",
                "5. Manage Movies",
                "6. Manage Updates & Ads",
                "7. Manage Licenses",
                "8. Show Profile",
                "9. Exit",
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

                Console.WriteLine("\nHome - CineComplex");
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
                        //Show scheduled shows
                        await ShowsView.Instance.View();
                        break;

                    case 2:
                        //Manage shows
                        await ManageShowsView.Instance.View();  
                        break;

                    case 3:
                        //Manage tickets
                        await ManageTicketsView.Instance.View();
                        break;

                    case 4:
                        //Manage theatre
                        await ManageTheatresView.Instance.View();
                        break;

                    case 5:
                        //Manage movies
                        await ManageMoviesView.Instance.View();
                        break;

                    case 6:
                        //Manage updates & ads
                        await ManageUpdatesAdsView.Instance.View();
                        break;

                    case 7:
                        //Manage Licenses
                        await ManageLicensesView.Instance.View();
                        break;

                    case 8:
                        //Manage Licenses
                        await ProfileView.Instance.View();
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice .....");
                        break;
                }
            } while (Choice != Instance.MenuList.Count);
        }
    }
}
