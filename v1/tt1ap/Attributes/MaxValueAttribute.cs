using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tt1ap.Exceptions;

namespace tt1ap.Attributes
{
    class MaxValueAttribute : ValidationAttribute
    {
        private readonly int _max;

        public MaxValueAttribute(int max)
        {
            _max = max;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int)
            {

                if ((int)value > _max)
                {
                    throw new MaxValueException("MaxValueError");
                }
            }

            return ValidationResult.Success;
        }
    }
}
