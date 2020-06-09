using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer
{
    public class CardNumberAttribute : ValidationAttribute
    {
        public CardNumberAttribute(int cardNumber)
            :base("{0} length must be 16 characters")
        {
            CardNumber = cardNumber;
        }

        public int CardNumber { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string variable = value.ToString();
            if(variable.Length > CardNumber || variable.Length < CardNumber)
            {
                var error = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(error);
            }
            return ValidationResult.Success;
        }
    }
}
