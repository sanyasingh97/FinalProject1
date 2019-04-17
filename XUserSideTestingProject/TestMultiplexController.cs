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
   public  class TestMultiplexController
    {
        

            MultiplexController controller;

            private ProjectTestDataContext context;
            public static DbContextOptions<ProjectTestDataContext> dbContextOptions { get; set; }

            public static string connectionString = "Data Source=TRD-507; Initial Catalog = a1; Integrated Security = true;";
            static TestMultiplexController()
            {
                dbContextOptions = new DbContextOptionsBuilder<ProjectTestDataContext>().UseSqlServer(connectionString).Options;
            }

            public TestMultiplexController()
            {
                context = new ProjectTestDataContext(dbContextOptions);
                controller = new MultiplexController();
            }


        // [Fact]
        //[Trait("Multiplex", "Index")]
        //public void Test2()
        //{
        //    Assert.Throws<NullReferenceException>(() =>
        //    {
        //        var controller = new MultiplexController();


        //        var data = controller.Index();
        //        Assert.IsType<RedirectToActionResult>(data);
        //    });

        //}
    }
}
