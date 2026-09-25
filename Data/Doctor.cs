using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract8_trpo.Data
{
    public class Doctor
    {
        public string ID { get; set; } // Идентификатор
        public string Name { get; set; } // Имя
        public string LastName { get; set; } // Фамилия
        public string MiddleName { get; set; } // Отчество
        public string Specialization { get; set; } // Специализация
        public string Password { get; set; } // Пароль
        public string RepeatPassword { get; set; } // Повторение пароля
    }
}
