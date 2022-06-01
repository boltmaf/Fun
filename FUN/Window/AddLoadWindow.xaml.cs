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
    /// Логика взаимодействия для AddLoadWindow.xaml
    /// </summary>
    public partial class AddLoadWindow : System.Windows.Window
    {
        public AddLoadWindow()
        {
            InitializeComponent();
            RefreshGroup();
            RefreshCbDiscipline();
        }
        /// <summary>
        /// Добавление нагрузки для группы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number = ((Group)CbLoadGroup.SelectedItem).NumberOfStudents;
                LoadGroup load = new LoadGroup()
                {
                    ID_Discipline = ((Discipline)CbLoadDiscipline.SelectedItem).ID,
                    ID_Group = ((Group)CbLoadGroup.SelectedItem).ID,
                    Lections = Convert.ToInt32(TbLoadLec.Text),
                    Practice = Convert.ToInt32(TbLoadPr.Text),
                    LR = Convert.ToInt32(TbLoadLR.Text),
                    GroupAndDis = ((Discipline)CbLoadDiscipline.SelectedItem).Name + " " + ((Group)CbLoadGroup.SelectedItem).Number
                };
                if (number >= 25)
                {
                    load.LR = 2 * load.LR;
                }
                _db.GetContext().LoadGroup.Add(load);
                _db.GetContext().SaveChanges();
                MessageBox.Show("Вы успешно добавили нагрузку для группы!" + "\n" + "Теперь можете добавить нагрузку для преподавателя!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
}


        /// <summary>
        /// Обновление дисциплин
        /// </summary>
        private void RefreshCbDiscipline()
        {
            CbLoadDiscipline.Items.Clear();
            foreach (FUN.Discipline u in _db.GetContext().Discipline)
            {
                CbLoadDiscipline.Items.Add(u);
            }
        }
        /// <summary>
        /// Обновление групп
        /// </summary>
        private void RefreshGroup()
        {
            CbLoadGroup.Items.Clear();
            foreach (FUN.Group gr in _db.GetContext().Group)
            {
                CbLoadGroup.Items.Add(gr);
            }
        }

        private void CbLoadDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbLoadDiscipline.SelectedItem != null)
            {
                Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.ID == ((Discipline)CbLoadDiscipline.SelectedItem).ID);
                TbLoadLec.Text = Convert.ToString(discipline.Lections);
                TbLoadPr.Text = Convert.ToString(discipline.Practice);
                TbLoadLR.Text = Convert.ToString(discipline.Laboratory);
            }
        }
    }
}
