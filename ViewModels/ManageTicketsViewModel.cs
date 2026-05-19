using Konsole.Classes.Base;
using Konsole.Interfaces;


namespace Konsole.ViewModels
{
    public class ManageTicketsViewModel : ABaseSingleton<ManageTicketsViewModel>, IViewModel
    {

        public ManageTicketsViewModel() { }

        public void BookTickets()
        {
            Console.Clear();
            Console.WriteLine("I will back...");
            Console.ReadLine();
        }


    }
}
