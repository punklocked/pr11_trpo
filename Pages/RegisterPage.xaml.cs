using pract8_trpo.Data;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace pract8_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private Doctor registeredDoctor = new Doctor();
        public Information info;
        Random rnd = new Random();

        public RegisterPage(Information _info)
        {
            InitializeComponent();
            info = _info;
            RegForm.DataContext = registeredDoctor;
        }
        
        private string CreateID()
        {
            if (!File.Exists("IDS.txt"))
            {
                StreamWriter sw1 = new StreamWriter("IDS.txt");
                sw1.Close();
            }
            string[] takenIDS = File.ReadAllLines("IDS.txt");
            int newID;
            bool taken = false;
            do
            {
                newID = rnd.Next(10000, 100000);
                foreach (string id in takenIDS)
                {
                    if (Convert.ToInt32(id) == newID)
                    {
                        taken = true;
                    }
                }

            } while (taken == true);

            StreamWriter sw = File.AppendText("IDS.txt");
            sw.WriteLine(newID);
            sw.Close();

            return newID.ToString();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (HasValidationErrors())
            {
                MessageBox.Show("Исправьте ошибки валидации");
                return;
            }

            if (registeredDoctor.Name != null &&
                registeredDoctor.LastName != null &&
                registeredDoctor.MiddleName != null &&
                registeredDoctor.Specialization != null &&
                registeredDoctor.Password != null)
            {
                if (registeredDoctor.Password == registeredDoctor.RepeatPassword)
                {
                    string ID = CreateID();
                    registeredDoctor.ID = ID;
                    string jsonString = JsonSerializer.Serialize(registeredDoctor);
                    File.WriteAllText($"D_{ID}.txt", jsonString);
                    MessageBox.Show($"Доктор зарегистрирован с идентификатором {ID}");
                    registeredDoctor = new Doctor();
                    RegForm.DataContext = registeredDoctor;
                    info.JSONFiles++;
                    info.Doctors++;
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private bool HasValidationErrors()
        {
            return Validation.GetHasError(TextBoxName) ||
                   Validation.GetHasError(TextBoxLastName) ||
                   Validation.GetHasError(TextBoxMiddleName) ||
                   Validation.GetHasError(TextBoxSpecialization) ||
                   Validation.GetHasError(TextBoxPassword) ||
                   Validation.GetHasError(TextBoxRepeatPassword);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
