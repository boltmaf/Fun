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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FUN
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MainFrame.Navigate(new Pages.DataPage());
        }

        private void MainDate_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.AddDiscipline());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.DataPage());
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
