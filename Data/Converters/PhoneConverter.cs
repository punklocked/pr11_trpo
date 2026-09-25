using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pract8_trpo.Data.Converters
{
    public class PhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string phone || phone.Length != 11 ||
                phone[0] != '8' || phone.Any(character => !char.IsDigit(character)))
            {
                return value?.ToString() ?? string.Empty;
            }

            return $"{phone[0]} ({phone.Substring(1, 3)}) {phone.Substring(4, 3)} {phone.Substring(7, 2)} {phone.Substring(9, 2)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
