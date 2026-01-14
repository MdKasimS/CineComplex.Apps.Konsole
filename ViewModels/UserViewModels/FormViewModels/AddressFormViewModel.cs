using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.ViewModels.UserViewModels.FormViewModels
{
    public class AddressFormViewModel : AViewModelBase<AddressFormViewModel>, IViewModel
    {
        #region Properties
        public string BuildingDetails { get; set; }
        public string Area { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string OtherDetails { get; set; }
        #endregion

        #region Methods

        public async Task AddAddressCommand()
        {
            Address _newAddress = new Address();
            _newAddress.BuildingDetails = BuildingDetails;
            _newAddress.StreetName = StreetName;
            _newAddress.Area = Area;
            _newAddress.City = City;
            _newAddress.State = State;
            _newAddress.Country = Country;
            _newAddress.OtherDetails = OtherDetails;
            _newAddress.PinCode = PinCode;
            _newAddress.AccountProfile = Credential.Instance.LoggedInUser.UserProfile;
            _newAddress.AccountProfileId = Credential.Instance.LoggedInUser.UserProfile.Id;
            await Address.CreateNewAddress(_newAddress);
        }

        public async Task ResetFormCommand()
        {
            await Task.Run(() =>
            {
                BuildingDetails = "";
                StreetName = "";
                Area = "";
                City = "";
                State = "";
                Country = "";
                OtherDetails = "";
                PinCode = "";
            });

        }

        #endregion
    }
}
