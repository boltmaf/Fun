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
        /// <summary>
        /// Добавление нагрузки для преподавателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddLoadTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 0;
                LoadGroup loadGroup = _db.GetContext().LoadGroup.FirstOrDefault(p => p.ID == ((LoadGroup)CbLoadTeacherLoad.SelectedItem).ID);
                LoadTeacher load = new LoadTeacher();
                load.ID_Load = ((LoadGroup)CbLoadTeacherLoad.SelectedItem).ID;
                load.ID_Teacher = ((Teacher)CbLoadTeacherTeacher.SelectedItem).ID;
                load.TeacherDisGroup = ((Teacher)CbLoadTeacherTeacher.SelectedItem).Name + "/" + loadGroup.Discipline.Name + "/" + Convert.ToString(loadGroup.Group.Number);
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
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }

        private void CbLoadTeacherLoad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChBoxLections.Visibility = Visibility.Visible;
            ChBoxPractice.Visibility = Visibility.Visible;
            ChBoxLR.Visibility = Visibility.Visible;
            if (CbLoadTeacherLoad.SelectedItem != null)
            {
                LoadGroup loadGroup = _db.GetContext().LoadGroup.FirstOrDefault(p => p.ID == ((LoadGroup)CbLoadTeacherLoad.SelectedItem).ID);
                TbLoadTeacherLec.Text = Convert.ToString(loadGroup.Lections);
                if (TbLoadTeacherLec.Text == "0")
                    ChBoxLections.Visibility = Visibility.Hidden;
                TbLoadTeacherPrac.Text = Convert.ToString(loadGroup.Practice);
                if (TbLoadTeacherPrac.Text == "0")
                    ChBoxPractice.Visibility = Visibility.Hidden;
                TbLoadTeacherLR.Text = Convert.ToString(loadGroup.LR);
                if (TbLoadTeacherLR.Text == "0")
                    ChBoxLR.Visibility = Visibility.Hidden;
            }
        }
    }
}
