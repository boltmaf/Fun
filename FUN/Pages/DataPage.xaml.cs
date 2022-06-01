
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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace FUN.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : System.Windows.Controls.Page
    {
        int summ = 0;
        public DataPage()
        {
            InitializeComponent();
            RefreshTeacher();
            RefreshGroup();
        }

        private void RefreshTeacher()
        {

            CbTeachersName.Items.Clear();
            foreach (FUN.Teacher t in _db.GetContext().Teacher)
            {
                CbTeachersName.Items.Add(t);
            }
        }

        private void RefreshGroup()
        {
            CbLoadGroupNumber.Items.Clear();
            foreach(Group t in _db.GetContext().Group)
            {
                CbLoadGroupNumber.Items.Add(t);
            }
        }

        private void LoadTeacher()
        {
            summ = 0;
            Teacher teacher = _db.GetContext().Teacher.FirstOrDefault(p => p.ID == ((Teacher)CbTeachersName.SelectedItem).ID);
            List<LoadTeacher> loadTeacher = new List<LoadTeacher>();
            List<Loads> loads = new List<Loads>();
            foreach (LoadTeacher u in _db.GetContext().LoadTeacher)
            {
                if (u.ID_Teacher == teacher.ID)
                {
                    loadTeacher.Add(u);

                }
            }
            for (int i = 0; i < loadTeacher.Count; i++)
            {
                loads.Add(new Loads()
                {
                    Discipline = loadTeacher[i].LoadGroup.Discipline.Name,
                    Teachers = loadTeacher[i].Teacher.Name,
                    Group = loadTeacher[i].LoadGroup.Group.Number,
                    Lections = loadTeacher[i].Lections,
                    Practice = loadTeacher[i].Practice,
                    LR = loadTeacher[i].LR
                });
                summ += Convert.ToInt32(loads[i].Lections) + Convert.ToInt32(loads[i].LR) + Convert.ToInt32(loads[i].Practice);
            }
            DgLoadTeachers.ItemsSource = null;
            DgLoadTeachers.ItemsSource = loads.ToList();
            TbSummLoad.Text = Convert.ToString(summ);
        }

        private void LoadGroup()
        {
            summ = 0;
            Group group = _db.GetContext().Group.FirstOrDefault(p => p.ID == ((Group)CbLoadGroupNumber.SelectedItem).ID);
            List<LoadTeacher> loadTeacher = new List<LoadTeacher>();
            List<Loads> loads = new List<Loads>();
            foreach (LoadTeacher u in _db.GetContext().LoadTeacher)
            {
                if (u.LoadGroup.Group.ID == group.ID)
                {
                    loadTeacher.Add(u);

                }
            }
            for (int i = 0; i < loadTeacher.Count; i++)
            {
                loads.Add(new Loads()
                {
                    Discipline = loadTeacher[i].LoadGroup.Discipline.Name,
                    Teachers = loadTeacher[i].Teacher.Name,
                    Group = loadTeacher[i].LoadGroup.Group.Number,
                    Lections = loadTeacher[i].Lections,
                    Practice = loadTeacher[i].Practice,
                    LR = loadTeacher[i].LR
                });
                summ += Convert.ToInt32(loads[i].Lections) + Convert.ToInt32(loads[i].LR) + Convert.ToInt32(loads[i].Practice);
            }
            DgLoadGroup.ItemsSource = null;
            DgLoadGroup.ItemsSource = loads.ToList();
            TbGroupSummLoad.Text = Convert.ToString(summ);
        }
        private void CbLoadGroupNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbLoadGroupNumber.Text != null)
            {
                LoadGroup();
            }
        }

        private void CbTeachersName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbTeachersName.Text != null)
            {
                LoadTeacher();
            }
        }

        private void BtnCreateDoc_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgLoadTeachers.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgLoadGroup.Columns[j].Header;
            }
            for (int i = 0; i < DgLoadTeachers.Columns.Count; i++)
            {
                for (int j = 0; j < DgLoadTeachers.Items.Count; j++)
                {
                    TextBlock b = DgLoadTeachers.Columns[i].GetCellContent(DgLoadTeachers.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }

        private void BtnCreateGroupDoc_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgLoadGroup.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgLoadGroup.Columns[j].Header;
            }
            for (int i = 0; i < DgLoadGroup.Columns.Count; i++)
            {
                for (int j = 0; j < DgLoadGroup.Items.Count; j++)
                {
                    TextBlock b = DgLoadGroup.Columns[i].GetCellContent(DgLoadGroup.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }
    }
}
