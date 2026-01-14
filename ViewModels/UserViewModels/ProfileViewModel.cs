using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.Models;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;


namespace CineComplex.ViewModels.UserViewModels
{
    public class ProfileViewModel : AViewModelBase<ProfileViewModel>, IViewModel
    {
        #region Properties

        public User LoggedInUser { get; set; } = Credential.Instance.LoggedInUser;

        #region Collections

        public ObservableCollection<Address> AddressesOfUser { get; set; }
        public ObservableCollection<BankAccount> BankAccountsOfUser { get; set; }

        #endregion

        #endregion

        #region Commands

        #endregion

        #region Methods

        public void Init()
        {
            if (AddressesOfUser.IsNullOrEmpty())
            {
                AddressesOfUser = new ObservableCollection<Address>();

                foreach (Address address in SQLInteraction.Db.Addresses.Where(ad => ad.AccountProfileId == Credential.Instance.LoggedInUser.UserProfileId))
                {
                    AddressesOfUser.Add(address);
                }
            }

            if (BankAccountsOfUser.IsNullOrEmpty())
            {
                BankAccountsOfUser = new ObservableCollection<BankAccount>();

                foreach (BankAccount account in SQLInteraction.Db.BankAccounts.Where(ad => ad.UserProfileId == Credential.Instance.LoggedInUser.UserProfileId).ToList())
                {
                    BankAccountsOfUser.Add(account);
                }
            }
        }

        #endregion
    }
}
