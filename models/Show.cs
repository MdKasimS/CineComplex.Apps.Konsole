using System.Collections.ObjectModel;

namespace CineComplex.Models
{
    enum ShowStatus
    {
        //Its upcoming and booking is available
        BookingAvailable,
        //Its upcoming and only counter booking is available
        BookingStopped,
        //Show is next and no booking allowed
        Upcoming,
        //Show is going on
        InRunning,
        //Show completed and no booking further
        Completed,
        //Show cancelled
        Cancelled,
        //Show cancelled but tickets updated for rescheduled slot
        Rescheduled
    }

    public class Show
    {
        public int Id { get; set; }
        public decimal PlatinumSeatRate { get ; set; }
        public decimal GoldSeatRate { get ; set; }
        public decimal SilverSeatRate { get ; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get ; set; }
        public Movie ShowMovie { get; set; }
        public int MovieId { get ; set; }// Foreign Key
        public Auditorium HostingAuditorium { get; set; }
        public int AuditoriumId { get ; set; }// Foreign Key
        public ObservableCollection<Ticket> TicketsOfTheShow { get; set; }
        public ObservableCollection<Booking> Bookings { get; set; }

        //TODO: Move this method to respective places
        public void DisplayShowDetails()
        {
            Console.WriteLine($"Show ID : {Id}");
            Console.WriteLine($"Movie ID : {MovieId}");
            Console.WriteLine($"Theatre ID : {AuditoriumId}");
            Console.WriteLine($"Platinum Seat Rate : {PlatinumSeatRate}");
            Console.WriteLine($"Gold Seat Rate : {GoldSeatRate}");
            Console.WriteLine($"Silver Seat Rate : {SilverSeatRate}");
        }
    }
}