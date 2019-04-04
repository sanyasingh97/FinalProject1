using Microsoft.AspNetCore.Mvc;
using System;
using UserProject.Controllers;
using Xunit;

namespace XUnitTestProjectAdmin
{
    public class UnitTest1
    {
        HomeController controller;
        public UnitTest1()
        {
            controller = new HomeController();
        }
        [Fact]
        [Trait("Home", "IndexTest")]
        public void Test1()
        {
            //Act
            IActionResult result = controller.Index();
            //Assert
            Assert.NotNull(result);

        }
        [Trait("Home", "About")]
        [Fact(DisplayName = "AboutTestMethod")]
        public void Test3()
        {
            ViewResult result = (ViewResult)controller.About();
            string msg = (string)result.ViewData["Message"];
            Assert.Equal("Your application description page.", msg);
        }
        [Trait("Home", "Contact")]
        [Fact(DisplayName = "ContactTestMethod")]
        public void Test2()
        {
            ViewResult result = (ViewResult)controller.Contact();
            string msg = (string)result.ViewData["Message"];
            Assert.Equal("Your contact page.", msg);
        }


        [Fact(DisplayName = "ExceptionTest")]
        [Trait("Home", "PrivacyTest")]
        public void Test()
        {
            //Act
            IActionResult result = controller.Privacy();
            //Assert
            Assert.NotNull(result);

        }

    }
}
