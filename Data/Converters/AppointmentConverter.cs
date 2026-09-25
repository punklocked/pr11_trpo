using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pract8_trpo.Data.Converters
{
    class AppointmentConverter : IValueConverter
    {
        public object Convert(object value, Type tagetType, object parameter, CultureInfo cultureinfo)
        {
            if (value == null)
            {
                return string.Empty;
            }
            ObservableCollection<Appointment> appointments = (ObservableCollection<Appointment>)value;
            if (appointments.Count == 0)
            {
                return "Первый приём в клинике";
            }
            TimeSpan timeSinceLastAppointmnent = DateTime.Today - appointments[appointments.Count - 1].Date;
            if (timeSinceLastAppointmnent.Days == 0)
            {
                return $"Последний приём был сегодня";
            }
            return $"Дней с последнего приёма: {Math.Ceiling(timeSinceLastAppointmnent.TotalDays)}";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return null;
        }
        public int GetDays(DateTime lastAppointment)
        {
            DateTime dateToday = DateTime.Today;
            return dateToday.Day - lastAppointment.Day;
        }
    }
}
