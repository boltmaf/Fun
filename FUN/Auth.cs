using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using _db = FUN.DBModel;

namespace FUN
{
    public class Auth
    {
        public string Login(string log, string pass)
        {
            Auth auth = new Auth();
            try
            {
                var users = _db.GetContext().Users;
                foreach (Users u in users)
                {
                    if (log == u.Log && pass == u.Pass)
                    {
                        return "true";
                    }
                }
                return "false";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "false";
            }

        }

        public string Registration(string log, string pass, string email)
        {
            Auth auth = new Auth();
            try
            {
                if (log != "" && pass != "" && email != "")
                {
                    var users = _db.GetContext().Users;
                    bool access = false;
                    foreach (Users u in users)
                    {
                        if (log == u.Log)
                        {
                            access = true;
                        }
                    }
                    if (access == false)
                    {
                        Users user = new Users() { Log = log, Pass = pass, Email = email, Role = "User" };
                        _db.GetContext().Users.Add(user);
                        _db.GetContext().SaveChanges();
                        MessageBox.Show("Успешная регистрация!");
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
                else return "empty";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "false";
            }
        }

        public bool AddTeacher(string name, string staffing, string education)
        {
            try
            {
                Teacher teacher = new Teacher() { Name = name, Education = education };
                _db.GetContext().Teacher.Add(teacher);
                _db.GetContext().SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool RemoveTeacher(string name)
        {
            try
            {
                Teacher teacher = _db.GetContext().Teacher.Where(s => s.Name == name).FirstOrDefault();
                _db.GetContext().Teacher.Remove(teacher);
                _db.GetContext().SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool EditTeacher(string name, string education)
        {
            try
            {
                Teacher teacher = _db.GetContext().Teacher.Where(s => s.Name == name).FirstOrDefault();
                _db.GetContext().Teacher.Remove(teacher);
                teacher.Education = education;
                _db.GetContext().Teacher.Add(teacher);
                _db.GetContext().SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}
