using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.Models;

namespace Konsole.Services
{
    public class SessionService : AServiceBase<SessionService>, IService
    {
        public static void TerminateSession(string tokenId)
        {
            Session.DeleteSession(tokenId);
        }

        public static async Task LogSession(Auth auth)
        {
            await Task.Run(() =>
            {
                Credential.Instance.UserSession = Session.CreateSession(auth);
            });
        }

    }
}
