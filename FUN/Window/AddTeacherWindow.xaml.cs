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
    /// Логика взаимодействия для AddTeacherWindow.xaml
    /// </summary>
    public partial class AddTeacherWindow : System.Windows.Window
    {
        public AddTeacherWindow()
        {
            InitializeComponent();
        }

        private void BtAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher() { 
                Name = TbTeacherName.Text, 
                Education = TbTeacherEducation.Text,
                Rate = Convert.ToDouble(TbTeacherStaffing.Text) };
            _db.GetContext().Teacher.Add(teacher);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили преподавателя!");
        }
    }
}
