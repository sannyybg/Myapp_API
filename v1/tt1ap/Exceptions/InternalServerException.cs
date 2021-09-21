using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tt1ap.Exceptions
{
    public class InternalServerException : Exception
    {
        public string Code = "InternalServerError";
        public InternalServerException(string txt) : base(txt)
        {

        }
    }
}
