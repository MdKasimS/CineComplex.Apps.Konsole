using CineComplex.Models.CineComplex.Models;
using System.Collections.ObjectModel;

namespace CineComplex.Models
{
    public class Auditorium
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public Theatre CineComplexTheatre { get; set; }
        public int TheatreId { get; set; }
        public ObservableCollection<Seat> SeatsInAudi { get; set; }
        public ObservableCollection<Show> AllShowsOfThisAuditorium { get; set; }
    }
}