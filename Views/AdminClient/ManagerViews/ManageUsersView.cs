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
            Instance.MenuList = new List<string>()
            {
                "1. Show Users",
                "2. Create User",
                "3. Update User",
                "4. Deactivate User",
                "5. Delete User",
                "6. Show User Bookings",
                "7. Exit"
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
            //Properties marked as NotMapped(hence set null) are also being used as columns for ConsoleTables
            Console.Clear();
            List<User> existingUsers = SQLInteraction.Db.Users.ToList();

            if (existingUsers.Any())
            {
                ConsoleTable table;
                int pageSize = 10;
                int currentPage = 0;
                bool hasMorePages = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t----- !!! Salam Hindusthan !!! -----");
                    Console.WriteLine("================================================");

                    Console.WriteLine("\nManage Users - CineComplex");
                    Console.WriteLine("-------------------------------------------------");

                    Console.WriteLine();

                    Console.WriteLine("\nUsers : ");
                    Console.WriteLine("---------------");

                    table = new ConsoleTable(new List<string>() { "Id", "UserName", "Contact", "Email" }.ToArray());
                    var pagedUsers = existingUsers.Skip(currentPage * pageSize).Take(pageSize);
                    foreach (User u in pagedUsers)
                    {
                        table.AddRow($"{u.Id}", $"{u.Username,-20}", $"{u.Contact,-5}", $"{u.Email,-25}");
                    }

                    if (pagedUsers.Count() != 0 && pagedUsers.Count() < 10)
                    {
                        for (int i = 0; i < 10 - pagedUsers.Count(); ++i)
                        {
                            table.AddRow("", "", "", "");
                        }
                    }

                    hasMorePages = pagedUsers.Count() == 0 ? false : true;
                    if (hasMorePages)
                    {
                        table.Write(Format.MarkDown);
                        Console.WriteLine($"Count {table.Rows.Count}");

                        currentPage++;

                        Console.WriteLine("\nMenu : ");
                        Console.WriteLine("---------------");
                        Console.WriteLine("1. Press Enter to view the next page");
                        Console.WriteLine("2. Enter Id For Record Selection");
                        Console.WriteLine("3. Type 3 to exit");
                        Console.Write("Your Choice: ");

                        var input = Console.ReadLine();
                        if (input?.ToLower() == "3")
                        {
                            break;
                        }

                    }
                } while (hasMorePages);

            }
            else
            {
                Console.WriteLine("No users found.");
            }
        }
    }
}
