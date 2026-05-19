using Konsole.Classes.Base;
using Konsole.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.ViewModels.CineplexViewModels.FormsViewModels
{
    public class ForgotPasswordFormViewModel: AViewModelBase<ForgotPasswordFormViewModel>, IViewModel
    {
        #region Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        #endregion

        #region Methods

        public void SetNewPasswordForUserId()
        {

        }

        #endregion
    }
}
