using CineComplex.Models;
using CineComplex.Classes.Base;
using CineComplex.Services;
using CineComplex.ViewModels.FormViewModels;
using CineComplex.Classes;
using Microsoft.Identity.Client;


namespace CineComplex.ViewModels.AdminViewModels
{
    public class SignInViewModel : AViewModelBase<SignInViewModel>
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

        public void ForgotPassword()
        {
            //Now this method is in VM and we need View to be created when this method is called. Don't know how to handle it?
            if (Instance.AreAllCredentialsAvailable())
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
            await Task.Run(() =>
            {
                AuthenticationResult = AuthenticationService.TerminateUserSession(Credential.Instance.SessionTokenId);
                ResetFormCommand();
            });

            //TODO: Use navigation state machine
        }

        public void ResetFormCommand()
        {
            Credential.Instance.LoginId = "";
            Credential.Instance.Password = "";
        }

        private bool AreAllCredentialsAvailable()
        {
            if (string.IsNullOrWhiteSpace(Credential.Instance.LoginId)
               || string.IsNullOrWhiteSpace(Credential.Instance.Password))
            {
                Console.Clear();
                Console.WriteLine("All fields are required. Press any key to continue...");
                Console.ReadKey();
                return false;
            }

            if (!AuthenticationService.IsValidEmail(Credential.Instance.LoginId).IsSuccessful)
            {
                Console.Clear();
                Console.WriteLine("Invalid user Id format. Press any key to continue...");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        
    }
}
