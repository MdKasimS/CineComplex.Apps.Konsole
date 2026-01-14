using CineComplex.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User UserAccount { get; set; } = null!;
        public ObservableCollection<Address> AddressDetails { get; set; }
        public ObservableCollection<BankAccount> BankDetails { get; set; }

        /* Need Attention!
            If user doesn't own any theatre, this collection will be empty
            For now just add it.The problem of integrating user and owners in same
            authentication system is still to be solved.
            This is to provision users to host shows in tehir spaces. A differentiating SOP.
        */
        public ObservableCollection<Theatre> Multiplexes { get; set; }
        public static UserProfile GetUserProfileByUserId(int userId)
        {
            return SQLInteraction.Db.UserProfiles.FirstOrDefault(up => up.UserId == userId);
        }
    }
}
