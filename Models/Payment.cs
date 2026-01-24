using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.Models
{
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        NetBanking,
        UPI,
        Wallet,
        Cash
    }

    public enum PaymentStatus
    {
        Pending,     // Payment initiated but not completed
        Completed,   // Payment successfully processed
        Failed,      // Payment attempt failed
        Refunded,    // Payment refunded back to user
        Cancelled    // Payment cancelled before completion
    }

    public class Payment
    {
        public int Id { get; set; }

        // Amount paid for the booking
        public decimal Amount { get; set; }

        // Payment method (CreditCard, DebitCard, UPI, NetBanking, Wallet, etc.)
        public PaymentMethod Method { get; set; }

        // Status of the payment (Pending, Completed, Failed, Refunded)
        public PaymentStatus Status { get; set; }

        // Transaction reference from payment gateway
        public string TransactionReference { get; set; }

        // When the payment was made
        public DateTime PaymentDate { get; set; }

        // Relationship: Payment belongs to one Booking
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        // Relationship: Payment belongs to one UserProfile
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }


    }
}
