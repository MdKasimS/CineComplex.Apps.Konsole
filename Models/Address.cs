using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string BuildingDetails { get; set; }
        public string Area { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string OtherDetails { get; set; }
        public int AccountProfileId { get; set; }
        public UserProfile AccountProfile { get; set; }

        public static async Task CreateNewAddress(Address _newAddress)
        {
            await Task.Run(() =>
            {
                SQLInteraction.Db.Attach(_newAddress.AccountProfile);
                SQLInteraction.Db.Addresses.Add(_newAddress);
                SQLInteraction.Db.SaveChanges();

            });
        }

        //TODO: Create method to check all data fields available for saving address
    }
}
