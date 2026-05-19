using System.Collections.ObjectModel;

namespace Konsole.Models
{
    public class Movie
    {
        public int Id {  get; set; }
        public string CinemaCode { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string DirectorName { get; set; }
        public string ProducerName { get; set; }
        public string Language { get; set; }
        public double Duration { get ; set; }
        public string Story { get; set; }
        public ObservableCollection<Show> MovieShows { get; set; }

    }
}