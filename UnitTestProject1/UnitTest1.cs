using FUN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AuthTest()
        {
            Auth auth = new Auth();
            string exp = "true";

            string actual = auth.Login("1", "1");

            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        public void RegTest()
        {
            Auth auth = new Auth();
            string exp = "true";

            string actual = auth.Registration("105", "123", "123");

            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        public void AddTeacherTest()
        {
            Auth auth = new Auth();

            bool exp = true;

            bool actual = auth.AddTeacher("Заид ЗЗ", "Полная", "Программист");

            Assert.AreEqual(exp, actual);
        }
        [TestMethod]
        public void DeleteTeacherTest()
        {
            Auth auth = new Auth();

            bool exp = true;

            bool actual = auth.RemoveTeacher("Заид ЗЗ");

            Assert.AreEqual(exp, actual);
        }
        [TestMethod]
        public void EditTeacherTest()
        {
            Auth auth = new Auth();

            bool exp = true;

            bool actual = auth.EditTeacher("Anton", "03.06.02");
            Assert.AreEqual(exp, actual);
        }
    }
}
