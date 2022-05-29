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
using _db = FUN.DBModel;


namespace FUN.Window
{
    /// <summary>
    /// Логика взаимодействия для AddLoadTeacher.xaml
    /// </summary>
    public partial class AddLoadTeacher : System.Windows.Window
    {
        public AddLoadTeacher()
        {
            InitializeComponent();
            RefreshTeacher();
            RefreshLoadGroup();
        }

        private void RefreshTeacher()
        {
            CbLoadTeacherTeacher.Items.Clear();
            foreach (FUN.Teacher t in _db.GetContext().Teacher)
            {
                CbLoadTeacherTeacher.Items.Add(t);
            }
        }

        private void RefreshLoadGroup()
        {
            CbLoadTeacherLoad.Items.Clear();
            foreach (LoadGroup load in _db.GetContext().LoadGroup)
            {
                CbLoadTeacherLoad.Items.Add(load);
            }
        }

        private void BtnAddLoadTeacher_Click(object sender, RoutedEventArgs e)
        {
            LoadGroup loadGroup = _db.GetContext().LoadGroup.FirstOrDefault(p => p.ID == ((LoadGroup)CbLoadTeacherLoad.SelectedItem).ID);
            LoadTeacher load = new LoadTeacher();
            load.ID_Load = ((LoadGroup)CbLoadTeacherLoad.SelectedItem).ID;
            load.ID_Teacher = ((Teacher)CbLoadTeacherTeacher.SelectedItem).ID;
            if (ChBoxLections.IsChecked == true)
            {
                loadGroup.Lections = 0;
                load.Lections = Convert.ToInt32(TbLoadTeacherLec.Text);
            }
            if (ChBoxPractice.IsChecked == true)
            {
                loadGroup.Practice = 0;
                load.Practice = Convert.ToInt32(TbLoadTeacherPrac.Text);
            }
            if (ChBoxLR.IsChecked == true)
            {
                loadGroup.LR = 0;
                load.LR = Convert.ToInt32(TbLoadTeacherLR.Text);
            }
            _db.GetContext().LoadTeacher.Add(load);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили нагрузку для преподавателя!");
        }

        private void CbLoadTeacherLoad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbLoadTeacherLoad.SelectedItem != null)
            {
                LoadGroup loadGroup = _db.GetContext().LoadGroup.FirstOrDefault(p => p.ID == ((LoadGroup)CbLoadTeacherLoad.SelectedItem).ID);
                TbLoadTeacherLec.Text = Convert.ToString(loadGroup.Lections);
                TbLoadTeacherPrac.Text = Convert.ToString(loadGroup.Practice);
                TbLoadTeacherLR.Text = Convert.ToString(loadGroup.LR);
            }
        }
    }
}
