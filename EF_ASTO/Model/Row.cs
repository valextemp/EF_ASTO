using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ASTO.Model
{
    public class Row
    {
        public int RowId { get; set; }
        public required string RowName { get; set; }

        public ICollection<Column> Columns { get; set; }
        public ICollection<Cell> LinkRowToCell { get; set; }
    }
}
