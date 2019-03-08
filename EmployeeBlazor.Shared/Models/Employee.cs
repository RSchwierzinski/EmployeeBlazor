using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBlazor.Shared.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
    }
}
