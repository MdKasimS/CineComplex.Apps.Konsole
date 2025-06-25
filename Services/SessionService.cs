using CineComplex.Classes;
using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.Services
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
