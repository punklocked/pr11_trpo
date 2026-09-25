using pract8_trpo.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
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

namespace pract8_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Page
    {
        public Doctor currentDoctor { get; set; }
        public Patient? currentPatient { get; set; }
        public ObservableCollection<Patient> Patients { get; set; } = new();

        Information info = new Information();

        public MainForm(Doctor _currentDoctor, Information _info)
        {
            InitializeComponent();
            info = _info;
            Patients = Information.PatientsList;
            Information.UpdateList();
            currentDoctor = _currentDoctor;
            InfoForm.DataContext = currentDoctor;
            FindBox.DataContext = info;
            DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(currentDoctor, Information.PatientsList, info));
        }

        private void AppointButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPatient != null)
            {
                NavigationService.Navigate(new AppointmentPage(currentPatient));
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPatient != null)
            {
                NavigationService.Navigate(new EditPage(currentPatient));
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPatient != null)
            {
                if (MessageBox.Show(
                    $"Вы точно хотите удалить пациента {currentPatient.Name}",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    info.JSONFiles--;
                    info.Patients--;
                    string[] IDS = File.ReadAllLines("Patient_IDS.txt");
                    using (StreamWriter sw = File.CreateText("Patient_IDS.txt"))
                    {
                        foreach (string id in IDS)
                        {
                            if (id != currentPatient.ID)
                            {
                                sw.WriteLine(id);
                            }
                        }
                    }
                    File.Delete($"P_{currentPatient.ID}");
                    currentPatient = null;
                    Information.UpdateList();
                }
            }
        }
    }
}
