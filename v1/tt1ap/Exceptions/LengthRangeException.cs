using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tt1ap.Exceptions
{
    public class LengthRangeException : Exception
    {
        public string Code = "LengthrangeError";
        public LengthRangeException(string txt) : base(txt)
        {

        }
    }
}
