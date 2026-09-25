using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pract8_trpo.Data.Converters
{
    class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type tagetType, object parameter, CultureInfo cultureinfo)
        {
            if (value == null)
            {
                return string.Empty;
            }
            int age = GetAge(DateTime.Parse(value.ToString()));
            if (age < 18)
            {
                return $"{age} Несовершеннолетний";
            }
            else if (age >= 18)
            {
                return $"{age} Совершеннолетний";
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return null;
        }
        public int GetAge(DateTime birthday)
        {
            DateTime dateToday = DateTime.Today;
            return dateToday.Year - birthday.Year;
        }
    }
}
