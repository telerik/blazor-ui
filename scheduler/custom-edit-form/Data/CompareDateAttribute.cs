using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace custom_edit_form.Data
{
    public class CompareDateAttribute : ValidationAttribute
    {
        public string compareToDateTimeProperty;

        public CompareDateAttribute(string compareToPropertyName)
        {
            this.compareToDateTimeProperty = compareToPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationObject = validationContext.ObjectInstance;
            PropertyInfo propertyInfo = validationObject.GetType().GetProperty(compareToDateTimeProperty);

            var currentValue = (DateTime?)value;
            var compareToValue = (DateTime?)propertyInfo?.GetValue(validationObject);

            return currentValue < compareToValue ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
