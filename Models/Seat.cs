using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.Models
{
    using Konsole.Models;

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace CineComplex.Models
    {
        public enum SeatType
        {
            Platinum,
            Gold,
            Seat
        }

        public enum SeatStatus
        {
            Active,
            Maintenance,
            Deactivated
        }

        public class Seat
        {
            public int Id { get; set; }
            public string SeatCode { get; set; }
            public SeatStatus SeatAvailability { get; set; }
            public SeatType TypeOfSeat { get; set; }
            public Auditorium AuditoriumOfTheTheatre { get; set; }
            public int AuditoriumId { get; set; }// Foreign Key
            public ObservableCollection<Ticket> Tickets { get; set; }
        }
    }
}
