using FamilyTree.Presentation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyTree.Presentation.Filters
{
    public class CustomAgeValidation : ValidationAttribute
    {
        ParentViewModel parent = new ParentViewModel();
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int parentAge = parent.Age;
            int childAge = parent.ChildAge;
            if (parentAge == 0) 
            {
                return new ValidationResult("Please provide this person's age.");
            }
            else
            {
                if (parentAge < childAge+18)
                {
                    return new ValidationResult("The parent can't be younger than the child");
                }
            }
            return ValidationResult.Success;
        }
    }
}