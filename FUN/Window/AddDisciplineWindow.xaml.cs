using System;
using FUN.Window;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using _db = FUN.DBModel;


namespace FUN.Window
{
    /// <summary>
    /// Логика взаимодействия для AddDisciplineWindow.xaml
    /// </summary>
    public partial class AddDisciplineWindow : System.Windows.Window
    {
        public AddDisciplineWindow()
        {
            InitializeComponent();
            RefreshCbSpezialization();
        }

        private void BtnAddDis_Click(object sender, RoutedEventArgs e)
        {
            if (TbDisLec.Text == null)
                TbDisLec.Text = "0";
            if (TbDisPrac.Text == null)
                TbDisPrac.Text = "0";
            if (TbDisLr.Text == null)
                TbDisLr.Text = "0";
            Discipline discipline = new Discipline()
            {
                Name = TbDisName.Text,
                ID_Speciality = ((Speciality)CbSpecDisciplineCode.SelectedItem).ID,
                Lections = Convert.ToInt32(TbDisLec.Text),
                Practice = Convert.ToInt32(TbDisPrac.Text),
                Laboratory = Convert.ToInt32(TbDisLr.Text),
                Year = Convert.ToInt32(TbDisYear.Text)
            };
            _db.GetContext().Discipline.Add(discipline);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили дисциплину!");
        }
        private void RefreshCbSpezialization()
        {
            CbSpecDisciplineCode.Items.Clear();
            foreach (FUN.Speciality u in _db.GetContext().Speciality)
            {
                CbSpecDisciplineCode.Items.Add(u);
            }
        }
    }
}
