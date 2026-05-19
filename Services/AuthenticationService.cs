using System.Text.RegularExpressions;

using Konsole.Classes;
using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.Models;

using Microsoft.IdentityModel.Tokens;

namespace Konsole.Services
{
    public class AuthenticationService : AServiceBase<AuthenticationService>, IService
    {

        public AuthenticationService()
        {
            Console.WriteLine("Authenticaition Service Is On...");
        }

        public static async Task<Result<bool>> AuthenticateUserForGivenCredential()
        {
            return await Task.Run(async () =>
            {

                if (!Credential.Instance.LoginId.IsNullOrEmpty() && !Credential.Instance.Password.IsNullOrEmpty())
                {
                    Result<bool> emailValidationResult = AuthenticationService.IsValidEmail(Credential.Instance.LoginId);

                    if (emailValidationResult.IsSuccessful)
                    {

                        User userToAuthenticate = User.GetUserByEmailId(Credential.Instance.LoginId);

                        if (userToAuthenticate != null)
                        {
                            Auth auth = SQLInteraction.Db.Auths.FirstOrDefault(a => a.UserId == userToAuthenticate.Id);
                            if (auth != null && auth.Password == Credential.Instance.Password)
                            {

                                await SessionService.LogSession(auth);

                                Credential.Instance.LoggedInUser = userToAuthenticate;
                                Credential.Instance.LoggedInUser.UserProfile = UserProfile.GetUserProfileByUserId(Credential.Instance.LoggedInUser.Id);
                                
                                return new Result<bool>(true, true, $"User {Credential.Instance.LoginId} Logged In..."); //false;
                            }
                            return new Result<bool>(false, false, $"Authentication Failed... Press Any Key To Continue.");
                        }

                        return new Result<bool>(false, false, $"User {Credential.Instance.LoginId} Doesn't Exists... Press Any Key To Continue.");
                    }
                    return emailValidationResult;
                }

                return new Result<bool>(false, false, "All Fields Are Needed... Press Any Key To Continue.");
            });
        }

        /// <summary>
        /// Check at https://www.rhyous.com/2010/06/15/csharp-email-regular-expression/
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Result<bool> IsValidEmail(string email)
        {

            String theEmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\-\w]+\.)+[a-zA-Z]{2,10})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\Z";
            if (Regex.IsMatch(email, theEmailPattern))
                return new Result<bool>(true, true, "");
            else
                return new Result<bool>(false, false, "Invalid Email Address. Press Any Key To Continue...");
        }

        public static Result<bool> AuthorizeNewUser(User _newUser)
        {
            try
            {
                if (SQLInteraction.Db.Users.Any(u => u.Contact == _newUser.Contact))
                {
                    return new Result<bool>(false, false, "Contact already exists. Press any key to continue..."); //false;
                }

                if (SQLInteraction.Db.Users.Any(u => u.Email == _newUser.Email))
                {
                    return new Result<bool>(false, false, "Email already registered. Press any key to continue..."); //false;
                }
                return new Result<bool>(true, true, ""); //true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Result<bool>(false, false, "Something Unusual Error Occured. Press any key to continue..."); //false;
            }
        }

        public static Result<bool> AreAllCredentialsAvailable()
        {
            if (string.IsNullOrWhiteSpace(Credential.Instance.LoginId)
               || string.IsNullOrWhiteSpace(Credential.Instance.Password))
            {
                return new Result<bool>(false, false, "All fields are required. Press any key to continue...\n");
            }

            if (!AuthenticationService.IsValidEmail(Credential.Instance.LoginId).IsSuccessful)
            {
                return new Result<bool>(false, false, "Invalid user Id format. Press any key to continue...");
            }
            return new Result<bool>(true, true, "");
        }
    
        public static Result<bool> TerminateUserSession(string authToken)
        {
            Session.DeleteSession(authToken);
            return new Result<bool>(true, true, $"User {Credential.Instance.LoginId} Logged Out...");
        }
    }
}
