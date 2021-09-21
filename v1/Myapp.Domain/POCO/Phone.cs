using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.Domain.POCO
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int TypeId { get; set; }
        public List<EmployeePhone> EmployeePhones { get; set; }
    }
}
