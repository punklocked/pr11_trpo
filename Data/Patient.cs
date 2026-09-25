using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract8_trpo.Data
{
    public class Patient
    {
        public string ID { get; set; } // Идентификатор
        public string Name { get; set; } // Имя
        public string LastName { get; set; } // Фамилия
        public string MiddleName { get; set; } // Отчество
        public string BirthdayString { get; set; } // Дата рождения
        public int LastDoctor { get; set; } // Последний доктор
        public string Diagnosis { get; set; } // Диагноз
        public string Recommendations { get; set; } // Рекомендации
        public string LastDoctorName { get; set; } // Имя последнего доктора
        public string PhoneNumber { get; set; } // Номер телефона

        public ObservableCollection<Appointment> AppointmentStories { get; set; } = new();

        private DateTime birthday = DateTime.Today;

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; BirthdayString = birthday.ToString("dd.MM.yyyy"); }
        }
    }
}
