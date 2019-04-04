using AdminProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using UserProject.Models;
using Xunit;

namespace XUnitTestProjectAdmin
{

    public class LocationTest
    {

        LocationController controller;
        public LocationTest()
        {
            controller = new LocationController();
        }

        [Fact]
        [Trait("Location", "Index")]
        public void TestForAllLocation()
        {
            //Arrange

            //Act
            ViewResult result = (ViewResult)controller.Index();

            //Assert
            //Assert.Same(result.Model, typeof(List<Location>));
            Assert.NotNull(result);
        }
        [Fact]
        [Trait("Location", "Create")]

        public void TestForCreate()
        {
            //Arrange
            //Act
            ViewResult result = (ViewResult)controller.Create();
            //Assert.Same(result.Model, typeof(List<Location>));
            Assert.NotNull(result);
            //Assert.Equal("1","Saket");


        }
        [Fact]
        [Trait("Location", "Create")]

        public void TestForEdit()
        {
            //Arrange
            //Act
            ViewResult result = (ViewResult)controller.Create();
            //Assert.Same(result.Model, typeof(List<Location>));
            Assert.NotNull(result);
            //Assert.Equal("1","Saket");


        }
    }
}
