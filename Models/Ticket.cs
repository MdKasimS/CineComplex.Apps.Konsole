using CineComplex.Models.CineComplex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.Models
{
    public enum TicketStatus
    {
        Active,
        CustomerCancelled,
        Expired,
        Redeemed,
        CinePlexCancelled
           
    }

    public class Ticket
    {
        public int Id { get; set; }
        public TicketStatus StatusOfTciket { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Show ShowBooked { get; set; }
        public int ShowId { get; set; }// Foreign Key
        public Seat SeatBooked { get; set; }
        public int SeatId { get; set; }// Foreign Key

    }
}
