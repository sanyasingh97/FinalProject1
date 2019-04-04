using System;
using System.Collections.Generic;
using System.Text;
using UserProject.Controllers;
using Xunit;

namespace XUnitTestProject2
{
    public class UnitTest2
    {
        AccountController controller;
        public UnitTest2()
        {
            controller = new AccountController();
        }
        [Trait("Account", "Login")]
        [Fact(DisplayName = "AccountLogin")]

        public void Test2()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                controller.Login("a", "1");
            });
        }
        [Trait("Account", "Logout")]
        [Fact(DisplayName = "AccountLogout")]

        public void Test3()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                controller.Logout();
            });
        }
    }
}

