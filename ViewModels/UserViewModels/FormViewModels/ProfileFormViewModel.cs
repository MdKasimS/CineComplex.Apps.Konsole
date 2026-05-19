using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.Models;

namespace Konsole.ViewModels.UserViewModels.FormViewModels
{
    public class ProfileFormViewModel : AViewModelBase<ProfileFormViewModel>, IViewModel
    {
        #region Properties
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }

        #endregion

        #region Command

        public async Task UpdateAndSaveCommand()
        {
            
            Credential.Instance.LoggedInUser.Username = UserName;
            Credential.Instance.LoggedInUser.Contact = Contact;
            Credential.Instance.LoggedInUser.Email = Email;
            //Credential.Instance.LoggedInUser.Password = Password;
            
            User.UpdateUser(Credential.Instance.LoggedInUser);
        }

        #endregion

        #region Methods

        public void Init()
        {
            UserName = Credential.Instance.LoggedInUser.Username;
            Email = Credential.Instance.LoggedInUser.Email;
            Contact = Credential.Instance.LoggedInUser.Contact;
            Password = Credential.Instance.Password;
        }
        #endregion
    }
}
