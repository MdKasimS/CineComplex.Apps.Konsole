using CineComplex.Classes.Base;
using CineComplex.Interfaces;


namespace CineComplex.ViewModels
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
