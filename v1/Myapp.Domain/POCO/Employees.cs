using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Myapp.Domain.POCO
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }


        public int Age { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        
        public string CardNumber { get; set; }


        public string Phone { get; set; }

        public string PersonalId { get; set; }
        public List<EmployeePhone> EmployeePhones { get; set; }
        public List<BankAccount> Accounts { get; set; }
    }
}
