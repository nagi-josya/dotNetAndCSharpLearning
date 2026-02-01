using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDeepDive.Models
{
    class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int ManagerId { get; set; }   // 0 = no manager
    }

}
