using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class StringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            var inputString = value.ToString();

            if (value == null)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }
            if (value == string.Empty)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }
            if (inputString.Length < 3)
            {
                return new ValidationResult(false, $"Строка должна содержать минимум 3 символа");
            }
            if (inputString.Length > 255)
            {
                return new ValidationResult(false, $"Строка должна содержать не более 255 символов");
            }

            if (ContainsDigits(inputString))
            {
                return new ValidationResult(false, "Строка не должна содержать цифры");
            }

            return ValidationResult.ValidResult;
        }
        private bool ContainsDigits(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
