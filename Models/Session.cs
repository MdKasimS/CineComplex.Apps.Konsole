namespace Konsole.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime LoginTimestamp { get; set; }
        public DateTime ExpirationTimestamp { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        //TODO: Please make it in ORM EFCore standard way

        public static Session CreateSession(Auth auth)
        {

            Session userSession = new Session()
            {
                UserId = auth.UserId,
                Token = Guid.NewGuid().ToString(), // Generate a unique token
                LoginTimestamp = DateTime.Now,
                ExpirationTimestamp = DateTime.Now.AddHours(1)
            };

            SQLInteraction.Db.Sessions.Add(userSession);
            SQLInteraction.Db.SaveChangesAsync();
            Credential.Instance.SessionTokenId = userSession.Token;
            return userSession;
        }

        public static void CleanSessions()
        {
            SQLInteraction.Db.Sessions.RemoveRange(SQLInteraction.Db.Sessions);
            SQLInteraction.Db.SaveChanges();
        }

        //This implements only one client can login or logout. Limiting screens
        //A new feature for multiple client with subscription can be developed
        public static void DeleteSession(string tokenId)
        {
            Session session = SQLInteraction.Db.Sessions.FirstOrDefault(s => s.Token == tokenId);
            if (session != null)
            {
                SQLInteraction.Db.Sessions.Remove(session);
                SQLInteraction.Db.SaveChanges();
            }
        }
    }
}
