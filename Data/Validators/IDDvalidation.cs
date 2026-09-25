using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class IDDvalidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            var inputString = value.ToString();

            if (value == null)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }

            if (!int.TryParse(inputString, out int intValue))
            {
                return new ValidationResult(false, $"ID состоит только из цифр");
            }

            if (inputString.Length != 5)
            {
                return new ValidationResult(false, $"ID состоит из 5 символов");
            }

            return ValidationResult.ValidResult;
        }
    }
}
