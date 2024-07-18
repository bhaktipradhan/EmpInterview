using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpInterview.Models
{
    public class EmployeeViewModel
    {
        public int Sr_No_ { get; set; }
        public string Name { get; set; }
        public string Dsg { get; set; }
        public string Dept { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
}