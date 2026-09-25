using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract8_trpo.Data.Validators
{
    class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (value == null)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }

            var input = Convert.ToDateTime(value);
            if (input >= DateTime.Now)
            {
                return new ValidationResult(false, "День рождения не может быть больше сегодняшнего");
            }
            if (input < DateTime.Today.AddYears(-125))
            {
                return new ValidationResult(false, "Неверный день рождения");
            }
            return ValidationResult.ValidResult;
        }
    }
}
