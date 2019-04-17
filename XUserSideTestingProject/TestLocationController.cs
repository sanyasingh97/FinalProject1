using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserProject1.Controllers;
using UserProject1.Models;
using Xunit;

namespace XUserSideTestingProject
{
    public class TestLocationController
    {

        LocationController controller;

        private ProjectTestDataContext context;
        public static DbContextOptions<ProjectTestDataContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-507; Initial Catalog = a1; Integrated Security = true;";
        static TestLocationController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProjectTestDataContext>().UseSqlServer(connectionString).Options;
        }

        public TestLocationController()
        {
            context = new ProjectTestDataContext(dbContextOptions);
            controller = new LocationController();
        }


        [Fact]
        [Trait("Location", "Index")]
        public void Test1()
        {
            //Act
            IActionResult result = controller.Index();
            //Assert
            Assert.NotNull(result);

        }













    }
}
