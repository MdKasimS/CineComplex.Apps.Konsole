using CineComplex.Models.CineComplex.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Models
{
    public enum TicketStatus
    {
        Issued, 
        Cancelled, 
        CheckedIn, 
        Expired,
        Refunded
    }

    public class Ticket
    {
        public int Id { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
        public Show ShowBooked { get; set; }
        public int ShowId { get; set; }// Foreign Key
        public Seat SeatBooked { get; set; }
        public int SeatId { get; set; }// Foreign Key
        public UserProfile User { get; set; }
        public int UserProfileId { get; set; }
    }
}
