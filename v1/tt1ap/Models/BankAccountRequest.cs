using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tt1ap.Models
{
    public class BankAccountRequest
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string CCY { get; set; }
        public decimal Amount { get; set; }
        public int PersonId { get; set; }

    }
}
