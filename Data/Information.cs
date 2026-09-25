using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pract8_trpo.Data
{
    public class Information : INotifyPropertyChanged
    {
        private int _jsonFiles { get; set; }
        public int JSONFiles // Количество JSON файлов
        {
            get { return _jsonFiles; }
            set { _jsonFiles = value; OnPropertyChanged(); }
        }
        private int _patients { get; set; }
        public int Patients // Количество пациентов
        {
            get { return _patients; }
            set { _patients = value; OnPropertyChanged(); }
        }
        private int _doctors { get; set; }
        public int Doctors // Количество докторов
        {
            get { return _doctors; }
            set { _doctors = value; OnPropertyChanged(); }
        }

        private static string findString { get; set; } = "";

        public static ObservableCollection<Patient> PatientsList = new();
        public string FindString
        {
            get { return findString; }
            set { findString = value; OnPropertyChanged(); UpdateList(); }
        }
        private static string GetDoctorByID(string ID)
        {
            if (File.Exists($"D_{ID}.txt"))
            {
                string jsonString = File.ReadAllText($"D_{ID}.txt");
                Doctor doctor = JsonSerializer.Deserialize<Doctor>(jsonString);
                return doctor.Name;
            }

            return "Не найден";
        }

        public static void UpdateList()
        {
            PatientsList.Clear();
            if (File.Exists("Patient_IDS.txt"))
            {
                using (StreamReader sr = File.OpenText("Patient_IDS.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        Patient patient;
                        string id = sr.ReadLine();
                        string jsonString = File.ReadAllText($"P_{id}.txt");
                        patient = JsonSerializer.Deserialize<Patient>(jsonString);
                        patient.LastDoctorName = GetDoctorByID(patient.LastDoctor.ToString());
                        if (patient.ID.StartsWith(findString))
                        {
                            PatientsList.Add(patient);
                        }
                        else if (findString == string.Empty)
                        {
                            PatientsList.Add(patient);
                        }
                    }
                }
            }
            else
                File.CreateText("Patient_IDS.txt");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
