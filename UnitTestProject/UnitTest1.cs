using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewProject.Pages;
using System;
using NewProject;

namespace NewProject.Pages {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("qwer", "1234567", false));
            Assert.IsFalse(page.Auth("yyrtyrt", "gggg", false));//несуществующие логин и пароль
        }
    }
}
