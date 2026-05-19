namespace Konsole.Models
{
    public class Credential
    {
        #region Private

        private string? _loginId;
        private string? _password;
        //private string? _type;
        private string? _sessionTokenId;
        private static Credential? _instance;

        #endregion

        #region Poperties

        public User LoggedInUser { get; set; }
        public Session UserSession { get; set; }
        
        #region Bools
        public bool IsSignedIn { get; set; }

        #endregion

        public string? LoginId { get => _loginId; set => _loginId = value; }
        public string? Password { get => _password; set => _password = value; }
        public string? SessionTokenId { get => _sessionTokenId; set => _sessionTokenId = value; }

        #endregion

        private Credential()
        {
        }
        public static Credential Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Credential();
                }
                return _instance;

            }
        }


    }
}