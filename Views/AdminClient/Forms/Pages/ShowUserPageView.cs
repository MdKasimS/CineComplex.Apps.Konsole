using Konsole.Classes.Base;
using Konsole.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Views.AdminClient.Forms.Pages
{
    public class ShowUserPageView : AViewBase<AdminHomeView>, IPage, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList { get; set; }
        public void LoadMenuList()
        {
            Instance.MenuList = new List<string>()
            {
                "1. Show All Users",
                "2. User By Id",
                "3. User By Name",
                "3. User By Contact",
                "3. User By City",
                "4. Active Users",
                "5. In-Active Users",
                "6. Deleted Users",
                "7. Exit",
            };
        }

        public Task View()
        {
            throw new NotImplementedException();
        }
    }
}
