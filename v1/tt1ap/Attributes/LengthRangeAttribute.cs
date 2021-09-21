using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tt1ap.Exceptions;

namespace tt1ap.Attributes
{
    class LengthRangeAttribute : ValidationAttribute
    {
        private readonly int _max;

        private readonly int _min;

        public LengthRangeAttribute(int min, int max)
        {
            _max = max;
            _min = min;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string val = value.ToString();
            if (val.Length < _max && val.Length > _min)
            {
                return ValidationResult.Success;
            }

            var ex = new LengthRangeException("Length is out of range");
            throw ex;
        }
    }
}
