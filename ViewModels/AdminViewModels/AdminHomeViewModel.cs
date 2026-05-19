using Konsole.Classes.Base;
using Konsole.Interfaces;
using Konsole.Models;
using Konsole.Services;

namespace Konsole.ViewModels.AdminViewModels
{
    public class AdminHomeViewModel : AViewModelBase<AdminHomeViewModel>, IViewModel
    {
        public void SignOut()
        {
            SessionService.TerminateSession(Credential.Instance.SessionTokenId);
        }

    }
}
