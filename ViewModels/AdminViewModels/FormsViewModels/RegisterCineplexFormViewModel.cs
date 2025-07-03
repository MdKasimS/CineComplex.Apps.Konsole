using CineComplex.Classes.Base;
using CineComplex.Interfaces;
using CineComplex.ViewModels.FormViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.ViewModels.AdminViewModels.FormsViewModels
{
    public class RegisterCineplexFormViewModel : AViewModelBase<RegisterCineplexFormViewModel>, IViewModel
    {
        #region Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public bool IsStep1 { get; set; }
        public bool IsStep2 { get; set; }
        public bool IsStep3 { get; set; }
        public bool IsStep4 { get; set; }
        public bool IsStep5 { get; set; }
        public bool IsStep6 { get; set; }
        #endregion
    }

    public enum StepStatus
    {
        Completed,
        Not_Completed
    }

}

