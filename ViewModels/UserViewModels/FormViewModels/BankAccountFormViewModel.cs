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
    class BankAccountFormViewModel : AViewModelBase<BankAccountFormViewModel>, IViewModel
    {
        #region Properties

        public string AccountNumber { get; set; }
        public string GSTNumber { get; set; }
        public string BankName { get; set; }
        public string IFSCNumber { get; set; }
        public string AccountHolderName { get; set; }

        #endregion

        #region Command

        public async Task AddBankAccountCommand()
        {
            BankAccount _newAccount = new BankAccount();
            _newAccount.AccountNumber = AccountNumber;
            _newAccount.GSTNumber = GSTNumber;
            _newAccount.IFSCNumber = IFSCNumber;
            _newAccount.AccountHolderName = AccountHolderName;
            _newAccount.BankName = BankName;
            _newAccount.AccountProfile = Credential.Instance.LoggedInUser.UserProfile;
            _newAccount.UserProfileId = Credential.Instance.LoggedInUser.UserProfile.Id;
            BankAccount.CreateNewBankAccount(_newAccount);
        }

        public void ResetFormCommand()
        {

        }

        #endregion
    }
}
