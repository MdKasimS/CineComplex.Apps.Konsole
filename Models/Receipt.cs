using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public Bill TotalBill { get; set; }

    }
}
