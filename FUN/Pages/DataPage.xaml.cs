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
using _db = FUN.DBModel;

namespace FUN.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPage()
        {
            InitializeComponent();
            CbTeacherLoad.Items.Clear();
            CbDisciplineLoad.Items.Clear();
            foreach (FUN.Teacher t in _db.GetContext().Teacher)
            {
                CbTeacherLoad.Items.Add(t);
            }
            foreach(Discipline d in _db.GetContext().Discipline)
            {
                CbDisciplineLoad.Items.Add(d);
            }

            
            

        }

        private void CbTeacherLoad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbDisciplineLoad.SelectedItem = -1;
            DgLoad.ItemsSource = _db.GetContext().HourlyLoad.Where(t => t.Teacher.Name == ((Teacher)CbTeacherLoad.SelectedItem).Name).ToList();
            DgLoad.Columns.RemoveAt(11);
            DgLoad.Columns.RemoveAt(11);
            DgLoad.Columns.RemoveAt(11);
            DgLoad.Columns.RemoveAt(11);
            DgLoad.Columns.RemoveAt(10);
        }

        private void CbDisciplineLoad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbTeacherLoad.SelectedItem = -1;
            DgLoad.ItemsSource = _db.GetContext().HourlyLoad.Where(t => t.Discipline.Name == ((Discipline)CbDisciplineLoad.SelectedItem).Name).ToList();
        }
    }
}
