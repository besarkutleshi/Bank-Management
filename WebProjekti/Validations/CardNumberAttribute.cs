using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekti.Validations
{
    public class CardNumberAttribute : ValidationAttribute
    {
        private string _cardnumber = "";
        private ApplicationDbContext _dbContext = null; 
        public CardNumberAttribute(string cardnumber)
            :base("{0} exist")
        {
            _cardnumber = cardnumber;
            _dbContext = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cardnumber = _dbContext.Accounts.FirstOrDefault(acc => acc.CardNumber == _cardnumber);
            if(cardnumber == null)
            {
                var error = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(error);
            }
            return ValidationResult.Success;
        }
    }
}
