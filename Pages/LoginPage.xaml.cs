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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private Doctor currentDoctor = new Doctor();
        Information info;

        public LoginPage(Information _info)
        {
            InitializeComponent();
            info = _info;
            LoginForm.DataContext = currentDoctor;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentDoctor.ID != string.Empty)
            {
                if (File.Exists($"D_{currentDoctor.ID}.txt"))
                {
                    string jsonString = File.ReadAllText($"D_{currentDoctor.ID}.txt");
                    Doctor tempDoctor = JsonSerializer.Deserialize<Doctor>(jsonString);
                    if (currentDoctor.Password == tempDoctor.Password)
                    {
                        currentDoctor = tempDoctor;
                        NavigationService.Navigate(new MainForm(currentDoctor, info));
                    }
                    else
                    {
                        currentDoctor = new Doctor();
                        LoginForm.DataContext = currentDoctor;
                        MessageBox.Show("Неверный пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage(info));
        }
    }
}
