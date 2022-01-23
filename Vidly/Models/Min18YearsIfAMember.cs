using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            else
            {
                if (customer.Birthdate == null)
                {
                    return new ValidationResult("Birthdate is required.");
                }
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18)
            
               ? ValidationResult.Success
               : new ValidationResult("Customer should beat list 18 years old to go on a membership.");
            
        }
    }
}