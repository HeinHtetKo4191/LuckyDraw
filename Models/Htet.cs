using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuckyD.Models
{
    public class Htet : ValidationAttribute
    {
        public ApplicationDbContext _context;
        public Htet()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (WinningNumber)validationContext.ObjectInstance;
            if (customer.PriceId == 7)
                return new ValidationResult("hein");
            return ValidationResult.Success;
            
        }
    }
}