using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Models
{
    public class Tax
    {
        public int Id { get; set; }
        public int ConutryCode { get; set; }
        public int PinCode { get; set; }
        public double Percentage { get; set; }
    }
}
