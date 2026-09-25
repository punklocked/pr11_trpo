using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using pract8_trpo.Data;

namespace pract8_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        Patient currentPatient;

        public AppointmentPage(Patient _currentPatient)
        {
            InitializeComponent();
            currentPatient = _currentPatient;
            DataContext = currentPatient;
        }

        private string GetDoctorByID(string ID)
        {
            if (File.Exists($"D_{ID}.txt"))
            {
                string jsonString = File.ReadAllText($"D_{ID}.txt");
                Doctor doctor = JsonSerializer.Deserialize<Doctor>(jsonString);
                return doctor.Name;
            }

            return "Не найден";
        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists($"P_{currentPatient.ID}.txt"))
            {
                Appointment appointment = new Appointment() { Date = DateTime.Today, Diagnosis = currentPatient.Diagnosis, Doctor_ID = currentPatient.LastDoctor, Recommendations = currentPatient.Recommendations };
                currentPatient.AppointmentStories.Add(appointment);
                string jsonString = JsonSerializer.Serialize(currentPatient);
                currentPatient.LastDoctorName = GetDoctorByID(currentPatient.LastDoctor.ToString());
                File.WriteAllText($"P_{currentPatient.ID}.txt", jsonString);
                MessageBox.Show($"Данные о пациенте обновлены");
                NavigationService.GoBack();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Information.UpdateList();
            NavigationService.GoBack();
        }
    }
}
