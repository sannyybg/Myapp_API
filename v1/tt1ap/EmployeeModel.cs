using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tt1ap.Attributes;
using tt1ap.Models;

namespace tt1ap
{
    public class EmployeeModel
    {
        [Required]
        [StringLength(8)]
        public string Name { get; set; }

        [MaxValue(60)]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        //[CreditCard]
        public string CardNumber { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        [LengthRange(8, 12)]
        public string PersonalId { get; set; }

        public List<PhoneRequest> Phones { get; set; }
        public List<BankAccountRequest> Accounts { get; set; }
    }
}
