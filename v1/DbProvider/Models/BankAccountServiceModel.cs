using DbProvider.VirtualDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProvider.Models
{
    public class BankAccountServiceModel
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string CCY { get; set; }
        public decimal Amount { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
