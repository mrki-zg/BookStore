using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookStore.Web.Models.Admin;

namespace BookStore.Web.Validation
{
    public class ValidUserRoleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var roles = (IList<string>) value;
            var validValues = Enum.GetNames(typeof(UserRoles));

            if (roles != null && roles.Any(r => !validValues.Contains(r)))
            {
                return new ValidationResult($"Some or all user roles are not supported! (Roles = {string.Join(",", roles)})");
            }

            return ValidationResult.Success;
        }
    }
}
