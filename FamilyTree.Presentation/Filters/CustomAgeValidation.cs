using FamilyTree.Presentation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyTree.Presentation.Filters
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CustomAgeValidation : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();

            Object childAge = type.GetProperty("ChildAge").GetValue(instance, null);

            if(value==null)
            {
                return new ValidationResult("The Age field is required.");
            }
            else
            {
                if((int)value<((int)(childAge)+18))
                {
                    return new ValidationResult("The parent must be at least 18 years older than the child");
                }
            }

            return ValidationResult.Success;
        }
    }
}
