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
    /// Логика взаимодействия для AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : System.Windows.Window
    {
        public AddGroupWindow()
        {
            InitializeComponent();
            RefreshCbSpezialization();
        }

        private void RefreshCbSpezialization()
        {
            CbSpesGroup.Items.Clear();
            foreach (FUN.Speciality u in _db.GetContext().Speciality)
            {
                CbSpesGroup.Items.Add(u);
            }
        }

        private void BtAddGroup_Click(object sender, RoutedEventArgs e)
        {
            Group group = new Group() { 
                Number = Convert.ToInt32(TbGrNumber.Text), 
                ID_Speciality = ((Speciality)CbSpesGroup.SelectedItem).ID, 
                SchollYear = TbGrYear.Text, 
                NumberOfStudents = Convert.ToInt32(TbGrStud.Text) };
            _db.GetContext().Group.Add(group);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили группу!");
        }
    }
}
