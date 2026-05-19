using Konsole.Classes;
using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.Models;

namespace Konsole.ViewModels.AdminViewModels.FormsViewModels
{
    public class SignUpFormViewModel : AViewModelBase<SignUpFormViewModel>, IViewModel
    {
        #region Properties

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Result<bool> SignUpResult { get; set; }

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

                SignUpResult = IsValidRegistration(_newUser);
                if (SignUpResult.IsSuccessful)
                {
                    await User.CreateNewUser(_newUser);

                    SignUpResult.Message = "Admin Created Successfully. Press Any Key To Continue...";
                    return SignUpResult;
                }
                return SignUpResult;
            });
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

        #endregion

    }
}
