using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class IDPvalidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            var inputString = value.ToString();

            if (inputString == string.Empty)
            {
                return ValidationResult.ValidResult;
            }

            if (!int.TryParse(inputString, out int intValue))
            {
                return new ValidationResult(false, $"ID состоит только из цифр");
            }

            if (inputString.Length > 7)
            {
                return new ValidationResult(false, $"ID пациента не может быть больше 7 цифр");
            }

            return ValidationResult.ValidResult;
        }
    }
}
