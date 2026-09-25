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

            var input = value.ToString();

            if (value == null)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }

            if (!long.TryParse(input, out long longValue))
            {
                return new ValidationResult(false, $"Номер телефона состоит только из цифр");
            }

            if (input.Length != 11)
            {
                return new ValidationResult(false, $"Номер телефона состоит из 11 символов");
            }
            if (input[0] != '8')
            {
                return new ValidationResult(false, $"Номер телефона должен начинаться на 8");
            }

            return ValidationResult.ValidResult;
        }
    }
}
