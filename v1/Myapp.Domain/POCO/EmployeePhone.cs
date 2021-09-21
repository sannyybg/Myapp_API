using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.Domain.POCO
{
    public class EmployeePhone
    {
        public int EmployeeId { get; set; }
        public int PhoneId { get; set; }
        public Employees Employee { get; set; }
        public Phone Phone { get; set; }
    }
}
