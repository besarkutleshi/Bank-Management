using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekti.Models.Account
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
            :base("{0} domain must be gmail")
        {
            this.allowedDomain = allowedDomain;
        }

        //public override bool IsValid(object value)
        //{
        //    string[] strings = value.ToString().Split('@');
        //    return strings[1].ToUpper() == allowedDomain.ToUpper();
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] strings = value.ToString().Split('@');
            if(strings[1].ToUpper() != allowedDomain.ToUpper())
            {
                var error = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(error);
            }
            return ValidationResult.Success;
        }
    }
}
