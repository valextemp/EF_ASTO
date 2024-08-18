using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ASTO.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        //------------------------------
        //Связи;
        public int? ManagerEmployeeId { get; set; }
        public Employee Manager { get; set; }
    }
}
