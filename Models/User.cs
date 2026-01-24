using CineComplex.Classes;
using CineComplex.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace CineComplex.Models
{
    public enum AccountStatus
    {
        Active,
        Disabled,
        Deleted
    }

    public class User
    {
        //TODO: Add account status control flag - Active, Disabled, Deleted
        public int Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore] // Optional: hides from JSON serialization
        [Browsable(false)]
        [NotMapped]
        //TODO: Make password inivisible
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public UserProfile UserProfile { get; set; }
        public int UserProfileId { get; set; }
        public AccountStatus Status { get; set; } = AccountStatus.Active;

        public static async Task CreateNewUser(User _newUser)
        {
            await Task.Run(() =>
            {
                SQLInteraction.Db.Users.Add(_newUser);
                SQLInteraction.Db.SaveChanges();

                //TODO: Hashing service to be added
                Auth auth = new Auth { 
                                        UserId = _newUser.Id,
                                        Password = _newUser.Password,
                                        PrivilegeLevel = 0
                                     };
                
                SQLInteraction.Db.Auths.Add(auth);
                SQLInteraction.Db.SaveChanges();

                UserProfile userProfile = new UserProfile
                {
                    UserId = _newUser.Id,
                    UserAccount = _newUser
                };

                // Add the new UserProfile to the context
                SQLInteraction.Db.UserProfiles.Add(userProfile);
                SQLInteraction.Db.SaveChanges();

                _newUser.UserProfile = userProfile;
                _newUser.UserProfileId = userProfile.Id;
                SQLInteraction.Db.Users.Update(_newUser);
                SQLInteraction.Db.SaveChanges();

                //SessionService.LogSession(auth);

            });
        }
        private static Result<bool> AreAllFieldsForRegistrationAvailable(User _newUser)
        {
            if (string.IsNullOrWhiteSpace(_newUser.Username)
                || string.IsNullOrWhiteSpace(_newUser.Password)
                || string.IsNullOrWhiteSpace(_newUser.Email)
                || string.IsNullOrWhiteSpace(_newUser.Contact))
            {
                return new Result<bool>(false, false, "All Fields Are Required. Press Any Key To Continue..."); ;//false;  
            }
            return new Result<bool>(true, true, ""); ;
        }
        public static Result<bool> IsValidUserRegistration(User _newUser)
        {
            Result<bool> isValidResult = AreAllFieldsForRegistrationAvailable(_newUser);
           //:TODO please remove any view related code
           if (isValidResult.IsSuccessful)
            {
                isValidResult = AuthenticationService.IsValidEmail(_newUser.Email);
                if (!isValidResult.IsSuccessful)
                {
                    return isValidResult; //false;
                }
                
                return AuthenticationService.AuthorizeNewUser(_newUser);
            }

            return isValidResult; //false; 
        }
        public static User GetUserByEmailId(string loginId)
        {
            return SQLInteraction.Db.Users.FirstOrDefault(u => u.Email == loginId);
        }
        public static User GetById(int id)
        {
            return SQLInteraction.Db.Users.FirstOrDefault(u => u.Id == id);
        }

        public static void UpdateUser(User _updatedUser)
        {
            SQLInteraction.Db.Users.Update(_updatedUser);
            SQLInteraction.Db.SaveChanges();
        }
    }
}
