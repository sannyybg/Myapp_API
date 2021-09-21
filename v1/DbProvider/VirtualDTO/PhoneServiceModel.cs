using DbProvider.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProvider.VirtualDTO
{
    public class PhoneServiceModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public PhoneType Type { get; set; }
    }
}
