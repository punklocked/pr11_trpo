using System.Text;
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
using pract8_trpo.Pages;
using pract8_trpo.Data;

namespace pract8_trpo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Information info = new Information();
        public MainWindow()
        {
            InitializeComponent();

            UpdateInfo();
            DataContext = info;
            MainFrame.Navigate(new LoginPage(info));
        }
        private void UpdateInfo()
        {
            if (File.Exists("IDS.txt") && File.Exists("Patient_IDS.txt"))
            {
                string[] DoctorIDS = File.ReadAllLines("IDS.txt");
                foreach (string ID in DoctorIDS)
                {
                    if (File.Exists($"D_{ID}.txt"))
                    {
                        info.JSONFiles++;
                        info.Doctors++;
                    }
                }
                string[] PatientIDS = File.ReadAllLines("Patient_IDS.txt");
                foreach (string ID in PatientIDS)
                {
                    if (File.Exists($"P_{ID}.txt"))
                    {
                        info.JSONFiles++;
                        info.Patients++;
                    }
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ThemeHelper.Toggle();
        }
    }
}