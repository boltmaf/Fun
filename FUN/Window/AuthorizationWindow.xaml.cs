using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FUN
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Auth auth = new Auth();
                string flag = auth.Login(TbLogin.Text, TbPassword.Text);
                if (flag == "true")
                {
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Вы ввели неверные данные!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
