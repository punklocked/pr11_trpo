using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pract8_trpo.Data
{
    public class Appointment
    {
        public string dateString { get; set; }
        public int Doctor_ID { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendations { get; set; }

        [JsonIgnore]

        private DateTime date = DateTime.Today;
        public DateTime Date
        {
            get { return date; }
            set { date = value; dateString = date.ToString("dd.MM.yyyy"); }
        }
    }
}
