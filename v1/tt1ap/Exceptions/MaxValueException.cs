using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tt1ap.Exceptions
{
    public class MaxValueException : Exception
    {
        public string Code = "MaxValueError";
        public MaxValueException(string txt) : base(txt)
        {

        }
    }
}
