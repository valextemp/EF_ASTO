using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ASTO.Model
{
    public class Cell
    {
        public int RowId { get; set; }
        public int ColumnId { get; set; }
        public decimal Value { get; set; }

        public Row Row { get; set; }
        public Column Column { get; set; }
    }
}
