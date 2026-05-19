using Konsole.Classes.Base;
using Konsole.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Classes
{
    public class FormData: ABaseSingleton<FormData>
    {
        public User UserFormObject { get; set; }

        public FormData() { }


    }
}
