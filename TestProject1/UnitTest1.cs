using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            User oUser = new User();
            Assert.AreEqual(true, oUser.login("admin", "admin"),"не правильный логин или пароль");
        }
    }
}