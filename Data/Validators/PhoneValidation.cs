using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class PhoneValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (value == null)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }

            var input = value.ToString();

            if (input.Length != 11)
            {
                return new ValidationResult(false, "Номер телефона состоит из 11 символов");
            }

            if (input.Any(character => !char.IsDigit(character)))
            {
                return new ValidationResult(false, "Номер телефона состоит только из цифр");
            }
            if (input[0] != '8')
            {
                return new ValidationResult(false, "Номер телефона должен начинаться на 8");
            }

            return ValidationResult.ValidResult;
        }
    }
}
