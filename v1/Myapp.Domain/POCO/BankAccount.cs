using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.Domain.POCO
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string CCY { get; set; }
        public decimal Amount { get; set; }
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }
        
    }
}
