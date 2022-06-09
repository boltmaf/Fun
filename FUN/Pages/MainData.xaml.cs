using Syncfusion.UI.Xaml.Grid.Converter;
using System;
using System.Collections.Generic;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;


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
            RefreshAll();
            
        }

        /// <summary>
        /// Обновление всего
        /// </summary>
        private void RefreshAll()
        {
            RefreshCbSpezialization();
            RefreshCbDiscipline();
            RefreshGroup();
            RefreshTeacher();
            RefreshLoadGroup();
            RefreshLoadTeacher();
        }


        /// <summary>
        /// Обновление специальностей
        /// </summary>
        private void RefreshCbSpezialization()
        {
            CbSpecDisciplineCode.Items.Clear();
            CbSpesGroup.Items.Clear();
            foreach (FUN.Speciality u in _db.GetContext().Speciality)
            {
                CbSpecDisciplineCode.Items.Add(u);
                CbSpesGroup.Items.Add(u);
            }
        }
        /// <summary>
        /// Обновление дисциплин
        /// </summary>
        private void RefreshCbDiscipline()
        {
            CbDisciplineName.Items.Clear();
            CbLoadDiscipline.Items.Clear();
            foreach (FUN.Discipline u in _db.GetContext().Discipline)
            {
                CbDisciplineName.Items.Add(u);
                CbLoadDiscipline.Items.Add(u);
            }
        }
        /// <summary>
        /// Обновление групп
        /// </summary>
        private void RefreshGroup()
        {
            CbGroupNumber.Items.Clear();
            CbLoadGroup.Items.Clear();
            foreach (FUN.Group gr in _db.GetContext().Group)
            {
                CbGroupNumber.Items.Add(gr);
                CbLoadGroup.Items.Add(gr);
            }
        }

        /// <summary>
        /// Обновление нагрузки
        /// </summary>
        private void RefreshLoadGroup()
        {
            CbLoadID.Items.Clear();
            CbLoadTeacherLoad.Items.Clear();
            foreach(LoadGroup load in _db.GetContext().LoadGroup)
            {
                CbLoadID.Items.Add(load);
                CbLoadTeacherLoad.Items.Add(load);
            }
        }
        /// <summary>
        /// Обновление нагрузки для преподавателя
        /// </summary>
        private void RefreshLoadTeacher()
        {
            CbLoadTeacherID.Items.Clear();
            foreach (LoadTeacher load in _db.GetContext().LoadTeacher)
            {
                CbLoadTeacherID.Items.Add(load);
            }
        }

        /// <summary>
        /// Обновление преподавателей
        /// </summary>
        private void RefreshTeacher()
        {
            CbTeacherName.Items.Clear();
            CbLoadTeacherTeacher.Items.Clear();
            foreach (FUN.Teacher t in _db.GetContext().Teacher)
            {
                CbTeacherName.Items.Add(t);
                CbLoadTeacherTeacher.Items.Add(t);
            }
        }



        /// <summary>
        /// Открытие окна для добавления данных о дисциплине
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddDis_Click(object sender, RoutedEventArgs e)
        {
            Window.AddDisciplineWindow addDiscipline = new Window.AddDisciplineWindow();
            addDiscipline.ShowDialog();
            RefreshAll();
        }
        /// <summary>
        /// Сохранение данных о дисциплине
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveDis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.ID == ((Discipline)CbDisciplineName.SelectedItem).ID);
                discipline.Name = TbDisName.Text;
                discipline.ID_Speciality = ((Speciality)CbSpecDisciplineCode.SelectedItem).ID;
                discipline.Lections = Convert.ToInt32(TbDisLec.Text);
                discipline.Practice = Convert.ToInt32(TbDisPrac.Text);
                discipline.Laboratory = Convert.ToInt32(TbDisLr.Text);
                discipline.Year = Convert.ToInt32(TbDisYear.Text);
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshCbDiscipline();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
}
        /// <summary>
        /// Изменение параметров в зависимости от Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbDisciplineName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbDisciplineName.SelectedItem != null)
                {
                    Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.ID == ((Discipline)CbDisciplineName.SelectedItem).ID);
                    TbDisID.Text = Convert.ToString(discipline.ID);
                    TbDisName.Text = discipline.Name;
                    CbSpecDisciplineCode.SelectedItem = _db.GetContext().Speciality.FirstOrDefault(p => p.ID == discipline.ID_Speciality);
                    TbDisLec.Text = Convert.ToString(discipline.Lections);
                    TbDisPrac.Text = Convert.ToString(discipline.Practice);
                    TbDisLr.Text = Convert.ToString(discipline.Laboratory);
                    TbDisYear.Text = Convert.ToString(discipline.Year);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Удаление дисциплины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteDis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Discipline discipline = _db.GetContext().Discipline.FirstOrDefault(p => p.ID == ((Discipline)CbDisciplineName.SelectedItem).ID);
                _db.GetContext().Discipline.Remove(discipline);
                _db.GetContext().SaveChanges();
                RefreshCbDiscipline();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Переход на окно с добавлением группы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            Window.AddGroupWindow addGroup = new Window.AddGroupWindow();
            addGroup.ShowDialog();
            RefreshAll();
        }
        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Group group = _db.GetContext().Group.FirstOrDefault(p => p.ID == ((Group)CbGroupNumber.SelectedItem).ID);
                _db.GetContext().Group.Remove(group);
                _db.GetContext().SaveChanges();
                RefreshGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
}

        /// <summary>
        /// Редактирование данных о группе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Group group = _db.GetContext().Group.FirstOrDefault(p => p.ID == ((Group)CbGroupNumber.SelectedItem).ID);
                group.Number = Convert.ToInt32(TbGrNumber.Text);
                group.ID_Speciality = ((Speciality)CbSpesGroup.SelectedItem).ID;
                group.SchollYear = TbGrYear.Text;
                group.NumberOfStudents = Convert.ToInt32(TbGrStud.Text);
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Изменение параметров в зависимости от Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbGroupNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbGroupNumber.SelectedItem != null)
                {

                    Group group = _db.GetContext().Group.FirstOrDefault(p => p.ID == ((Group)CbGroupNumber.SelectedItem).ID);
                    TbGrID.Text = Convert.ToString(group.ID);
                    TbGrNumber.Text = Convert.ToString(group.Number);
                    CbSpesGroup.SelectedItem = _db.GetContext().Speciality.FirstOrDefault(p => p.ID == group.ID_Speciality);
                    TbGrYear.Text = group.SchollYear;
                    TbGrStud.Text = Convert.ToString(group.NumberOfStudents);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// Открытие окна для добавления преподавателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            Window.AddTeacherWindow addTeacher = new Window.AddTeacherWindow();
            addTeacher.ShowDialog();
            RefreshAll();
        }

        /// <summary>
        /// Удаление преподавателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            Teacher teacher = _db.GetContext().Teacher.FirstOrDefault(p => p.ID == ((Teacher)CbTeacherName.SelectedItem).ID);

            _db.GetContext().Teacher.Remove(teacher);
            _db.GetContext().SaveChanges();
            RefreshTeacher();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Редактирование данных о преподавателе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Teacher teacher = _db.GetContext().Teacher.FirstOrDefault(p => p.ID == ((Teacher)CbTeacherName.SelectedItem).ID);
                teacher.Name = TbTeacherName.Text;
                teacher.Education = TbTeacherEducation.Text;
                teacher.Rate = Convert.ToDouble(TbTeacherStaffing.Text);
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshTeacher();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
}
        /// <summary>
        /// Изменение параметров в зависимости от Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTeacherName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            if (CbTeacherName.SelectedItem != null)
            {
                Teacher teacher = _db.GetContext().Teacher.FirstOrDefault(p => p.ID == ((Teacher)CbTeacherName.SelectedItem).ID);
                TbTeacherID.Text = Convert.ToString(teacher.ID);
                TbTeacherName.Text = teacher.Name;
                TbTeacherEducation.Text = teacher.Education;
                TbTeacherStaffing.Text = Convert.ToString(teacher.Rate);
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Изменение параметров в зависимости от Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbLoadID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbLoadID.SelectedItem != null)
                {
                    LoadGroup loadGroup = _db.GetContext().LoadGroup.FirstOrDefault(p => p.ID == ((LoadGroup)CbLoadID.SelectedItem).ID);
                    TbLoadID.Text = Convert.ToString(loadGroup.ID);
                    CbLoadGroup.SelectedItem = _db.GetContext().Group.FirstOrDefault(p => p.ID == loadGroup.ID_Group);
                    CbLoadDiscipline.SelectedItem = _db.GetContext().Discipline.FirstOrDefault(p => p.ID == loadGroup.ID_Discipline);
                    TbLoadLec.Text = Convert.ToString(loadGroup.Lections);
                    TbLoadPr.Text = Convert.ToString(loadGroup.Practice);
                    TbLoadLR.Text = Convert.ToString(loadGroup.LR);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// Добавление нагрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddLoad_Click(object sender, RoutedEventArgs e)
        {
            Window.AddLoadWindow addLoad = new Window.AddLoadWindow();
            addLoad.ShowDialog();
            RefreshAll();
        }
        /// <summary>
        /// Удаление нагрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            LoadGroup loadGroup = _db.GetContext().LoadGroup.FirstOrDefault(p => p.ID == ((LoadGroup)CbLoadID.SelectedItem).ID);
            _db.GetContext().LoadGroup.Remove(loadGroup);
            _db.GetContext().SaveChanges();
            RefreshLoadGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Сохранение нагрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadGroup loadGroup = _db.GetContext().LoadGroup.FirstOrDefault(p => p.ID == ((LoadGroup)CbLoadID.SelectedItem).ID);
                loadGroup.ID_Discipline = ((Discipline)CbLoadDiscipline.SelectedItem).ID;
                loadGroup.ID_Group = ((Group)CbLoadGroup.SelectedItem).ID;
                loadGroup.GroupAndDis = ((Discipline)CbLoadDiscipline.SelectedItem).Name + " " + ((Group)CbLoadGroup.SelectedItem).Number;
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                RefreshLoadGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }

        }

        /// <summary>
        /// Открытие окна для добавления нагрузки преподавателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddLoadTeacher_Click(object sender, RoutedEventArgs e)
        {
            Window.AddLoadTeacher addLoadTeacher = new Window.AddLoadTeacher();
            addLoadTeacher.ShowDialog();
            RefreshAll();
        }

        /// <summary>
        /// Изменение параметров в зависимости от Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbLoadTeacherID_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (CbLoadTeacherID.SelectedItem != null)
                {
                    LoadTeacher loadTeacher = _db.GetContext().LoadTeacher.FirstOrDefault(p => p.ID == ((LoadTeacher)CbLoadTeacherID.SelectedItem).ID);
                    TbLoadTeacherId.Text = Convert.ToString(loadTeacher.ID);
                    CbLoadTeacherLoad.SelectedItem = _db.GetContext().LoadGroup.FirstOrDefault(p => p.ID == loadTeacher.ID_Load);
                    CbLoadTeacherTeacher.SelectedItem = _db.GetContext().Teacher.FirstOrDefault(p => p.ID == loadTeacher.ID_Teacher);
                    TbLoadTeacherLec.Text = Convert.ToString(loadTeacher.Lections);
                    TbLoadTeacherPrac.Text = Convert.ToString(loadTeacher.Practice);
                    TbLoadTeacherLR.Text = Convert.ToString(loadTeacher.LR);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Удаление нагрузки для преподавателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelLoadTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadTeacher loadTeacher = _db.GetContext().LoadTeacher.FirstOrDefault(p => p.ID == ((LoadTeacher)CbLoadTeacherID.SelectedItem).ID);
                _db.GetContext().LoadTeacher.Remove(loadTeacher);
                _db.GetContext().SaveChanges();
                RefreshLoadTeacher();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!" + "\n" + ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateDoc_Click(object sender, RoutedEventArgs e)
        {
            /*var options = new ExcelExportingOptions();
            options.ExportMode = ExportMode.Text;
            var excelEngine = Dg.ExportToExcel(Dg.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];
            workBook.SaveAs("Sample.xlsx");*/
        }
    }
}
