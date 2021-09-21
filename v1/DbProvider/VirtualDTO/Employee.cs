using DbProvider.Models;
using System.Collections.Generic;

namespace DbProvider.VirtualDTO
{
    public class Employee : VirtualDTOMain
    {
        
        public string Name { get; set; }

        
        public int Age { get; set; }

        
        public string Email { get; set; }

        
        public string CardNumber { get; set; }

        
        public string Phone { get; set; }
        
        public string PersonalId { get; set; }

        public List<PhoneServiceModel> Phones { get; set; }

        public List<BankAccountServiceModel> Accounts { get; set; }




    }
}
