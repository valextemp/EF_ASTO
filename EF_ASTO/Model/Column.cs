using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ASTO.Model
{
    public class Column
    {
        public int ColumnId { get; set; }
        public string ColumnName { get; set; }
        //public ICollection<Row> Rows { get; set; }
        public ICollection<Cell> LinkColumnToCell { get; set; }

    }
}
