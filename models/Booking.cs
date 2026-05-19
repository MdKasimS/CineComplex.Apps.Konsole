namespace Konsole.Models
{
    public enum BookingStatus
    {
        Pending,    // Booking created but not yet confirmed (e.g., awaiting payment)
        Confirmed,  // Booking confirmed and tickets issued
        Cancelled,  // Booking cancelled by user or system
        Expired     // Booking expired due to non-payment or no-show
    }

    public class Booking
    {
        public int Id { get; set; }

        // Status of the booking (Pending, Confirmed, Cancelled, Expired)
        public BookingStatus Status { get; set; }

        // When the booking was created
        public DateTime CreatedAt { get; set; }

        // Foreign key to User (who made the booking)
        public int UserProfileId { get; set; }
        public UserProfile User { get; set; }

        // Foreign key to Show (which movie/showtime this booking is for)
        public int ShowId { get; set; }
        public Show Show { get; set; }

        // Collection of tickets under this booking
        // Note: Redundant booking reference in Ticket for easier access
        public ICollection<Ticket> Tickets { get; set; }

        // One-to-one relationship with Payment
        public Payment Payment { get; set; }


    }
}