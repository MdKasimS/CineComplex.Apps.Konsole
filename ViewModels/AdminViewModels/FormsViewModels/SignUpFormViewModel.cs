using CineComplex.Classes;
using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.Models;
using CineComplex.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.ViewModels.AdminViewModels.FormViewModels
{
    public class SignUpFormViewModel : AViewModelBase<SignUpFormViewModel>, IViewModel
    {
        #region Properties

        public string UserName{get;  set ; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        #endregion

        #region Commands

        public async Task<Result<bool>> CreateUserCommand()
        {
            return await Task.Run(async () =>
            {
                User _newUser = new User();
                _newUser.Username = UserName;
                _newUser.Password = Password;
                _newUser.Email = Email;
                _newUser.Contact = Contact;

                Result<bool> isValidRegistration = IsValidRegistration(_newUser);
                if (isValidRegistration.IsSuccessful)
                {
                    await User.CreateNewUser(_newUser);

                    isValidRegistration.Message = "User Created Successful. Press Any Key To Continue...";
                    return isValidRegistration;
                }
                return isValidRegistration;
            });
        }

        private Result<bool> IsValidRegistration(User _newUser)
        {
            Result<bool> isValidRegistration = User.IsValidUserRegistration(_newUser);
            
            if (isValidRegistration.IsSuccessful)
            {
                isValidRegistration.Value = true;
                isValidRegistration.IsSuccessful = true;
                return isValidRegistration;
            }

            return isValidRegistration;

        }

        public void ResetFormCommand()
        {
            SignUpFormViewModel.Instance.UserName = "";
            SignUpFormViewModel.Instance.Email = "";
            SignUpFormViewModel.Instance.Contact = "";
            SignUpFormViewModel.Instance.Password = "";
        }
        #endregion

        #region Methods


        #endregion
    }
}
