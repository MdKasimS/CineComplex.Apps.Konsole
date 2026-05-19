using Konsole.Interfaces;
using Konsole.Classes;
using Konsole.Services;
using Konsole.Classes.Base;
using Konsole.Models;


namespace Konsole.ViewModels.UserViewModels
{
    public class SignInViewModel : AViewModelBase<SignInViewModel>, IViewModel
    {
        public SignInViewModel() { }

        #region Properties

        public Result<bool> AuthenticationResult { get; set; }
        #endregion

        public void GetSignInId()
        {
            Credential.Instance.LoginId = Console.ReadLine();
        }
        
        public void GetSignIPassword()
        {
            Credential.Instance.Password = Console.ReadLine();
        }

        public async Task ForgotPasswordCommand()
        {
            //Now this method is in VM and we need View to be created when this method is called. Don't know how to handle it?
            if (AuthenticationService.AreAllCredentialsAvailable().IsSuccessful)
            {

            }

        }

        public async Task SignInCommand()
        {
            AuthenticationResult = AuthenticationService.AuthenticateUserForGivenCredential().Result;

            if (AuthenticationResult.IsSuccessful)
            {
                Credential.Instance.IsSignedIn = true;
            }
        }

        public async Task SignOutCommand()
        {
            AuthenticationResult = AuthenticationService.TerminateUserSession(Credential.Instance.SessionTokenId);
            ResetFormCommand();

            //TODO: Use navigation state machine
        }

        public async Task ResetFormCommand()
        {
            Credential.Instance.LoginId = "";
            Credential.Instance.Password = "";
        }


    }
}
