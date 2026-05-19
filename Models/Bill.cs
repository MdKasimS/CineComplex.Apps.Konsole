using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public Tax TaxLevied { get; set; }

        public Discount AppliedDiscount { get; set; }
    }
}
