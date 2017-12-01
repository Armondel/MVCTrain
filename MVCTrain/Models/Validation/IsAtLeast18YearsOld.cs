using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTrain.Models.Validation
{
    public class IsAtLeast18YearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (customer.BirthdayDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Now.Year - customer.BirthdayDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("You need to be at least 18 years old to earn membership. ");
        }
    }
}