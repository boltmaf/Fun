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
    /// Логика взаимодействия для AddDiscipline.xaml
    /// </summary>
    public partial class AddDiscipline : Page
    {
        int i=0;
        public AddDiscipline()
        {
            InitializeComponent();
            RefreshCbSpezialization();
            RefreshCbDiscipline();
            RefreshGroup();
            RefreshTeacher();
        }

        private void BtAddSpec_Click(object sender, RoutedEventArgs e)
        {
            Speciality speciality = new Speciality() { Code = TbSpecCode.Text, Name = TBSpecName.Text };
            _db.GetContext().Speciality.Add(speciality);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили специальность!");
            RefreshCbSpezialization();

        }


        private void RefreshCbSpezialization()
        {
            CbSpecCode.Items.Clear();
            CbSpecDisciplineCode.Items.Clear();
            CbSpesGroup.Items.Clear();
            foreach (FUN.Speciality u in _db.GetContext().Speciality)
            {
                CbSpecCode.Items.Add(u);
                CbSpecDisciplineCode.Items.Add(u);
                CbSpesGroup.Items.Add(u);
            }
        }

        private void RefreshCbDiscipline()
        {
            CbDisciplineName.Items.Clear();
            CbDisLoad.Items.Clear();
            foreach (FUN.Discipline u in _db.GetContext().Discipline)
            {
                CbDisciplineName.Items.Add(u);
                CbDisLoad.Items.Add(u);
            }
        }
        private void RefreshGroup()
        {
            CbGroupNumber.Items.Clear();
            foreach (FUN.Group gr in _db.GetContext().Group)
            {
                CbGroupNumber.Items.Add(gr);
            }
        }

        private void RefreshTeacher()
        {
            CbTeacherName.Items.Clear();
            CbTeacherLoad.Items.Clear();
            foreach (FUN.Teacher t in _db.GetContext().Teacher)
            {
                CbTeacherName.Items.Add(t);
                CbTeacherLoad.Items.Add(t);
            }
        }

        private void BtAddDis_Click(object sender, RoutedEventArgs e)
        {
            Discipline discipline = new Discipline() { Name = TbDisName.Text, ID_Speciality = ((Speciality)CbSpecDisciplineCode.SelectedItem).ID };
            _db.GetContext().Discipline.Add(discipline);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили дисциплину!");
            RefreshCbDiscipline();
        }

        private void BtAddLoad_Click(object sender, RoutedEventArgs e)
        {
            HourlyLoad hourlyLoad = new HourlyLoad()
            {
                SemesterNumber = Convert.ToInt32(TbSemNumber.Text),
                Lection = Convert.ToInt32(TbLection.Text),
                Practice = Convert.ToInt32(TbPractice.Text),
                LabWork = Convert.ToInt32(TbLR.Text),
                CourseWork = Convert.ToInt32(TbCR.Text),
                Consultation = Convert.ToInt32(TbConsult.Text),
                Exam = Convert.ToInt32(TbExam.Text),
                Summ = Convert.ToInt32(TbLection.Text) + Convert.ToInt32(TbPractice.Text) + Convert.ToInt32(TbLR.Text) + Convert.ToInt32(TbCR.Text) + Convert.ToInt32(TbConsult.Text) + Convert.ToInt32(TbExam.Text),
                Offset = TbOffset.Text,
                ID_discipline = ((Discipline)CbDisLoad.SelectedItem).ID

            };

            _db.GetContext().HourlyLoad.Add(hourlyLoad) ;
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили нагрузку для дисциплины " + hourlyLoad.Discipline.Name);
            RefreshCbDiscipline();


        }

        private void BtRefreshSumm_Click(object sender, RoutedEventArgs e)
        {
            i = Convert.ToInt32(TbLection.Text) + Convert.ToInt32(TbPractice.Text) + Convert.ToInt32(TbLR.Text) + Convert.ToInt32(TbCR.Text) + Convert.ToInt32(TbConsult.Text) + Convert.ToInt32(TbExam.Text);
            TbSumm.Text = Convert.ToString(i);
        }

        private void BtAddGroup_Click(object sender, RoutedEventArgs e)
        {
            Group group = new Group() { Number = Convert.ToInt32(TbGrNumber.Text), ID_Speciality = ((Speciality)CbSpesGroup.SelectedItem).ID , SchollYear = TbGrYear.Text, NumberOfStudents = Convert.ToInt32(TbGrStud.Text)};
            _db.GetContext().Group.Add(group);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили группу для специальности! " + group.Speciality.Name);
            RefreshGroup();
        }

        private void BtAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher() { Name = TbTeacherName.Text, Staffing = TbTeacherStaffing.Text, Education = TbTeacherEducation.Text };
            _db.GetContext().Teacher.Add(teacher);
            _db.GetContext().SaveChanges();
            MessageBox.Show("Вы успешно добавили преподавателя!");
            RefreshTeacher();
        }
    }
}
