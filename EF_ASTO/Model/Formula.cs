using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ASTO.Model
{
    public class Formula
    {
        public int FormulaId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
    }
}
