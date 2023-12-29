using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRentalProject.Models
{
    public class MinAge18IfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.Unknown) {
                return ValidationResult.Success;
            }
            if(customer.Birthday==null)
            {
                return new ValidationResult("Enter Birthday To Select Membership");
            }
            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age>18)? ValidationResult.Success: new ValidationResult("Underage to Select a Membership");
        }
    }
}