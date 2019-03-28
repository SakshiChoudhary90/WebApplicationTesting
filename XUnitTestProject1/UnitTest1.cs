using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using WebApplicationTesting.Controllers;
using WebApplicationTesting.Models;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        HomeController controller;
        public UnitTest1()
        {
            controller = new HomeController();
        }
        [Fact(DisplayName = "IndexTestMethod")]
        [Trait("Home", "IndexTest")]
 
        public void Test1()
        {
            // Act
            IActionResult result = controller.Index();
            //Assert
            Assert.NotNull(result);
        }

        [Trait("Home","Contact")]
        [Fact(DisplayName ="ContactTestMethod")]
        public void Test2()
        {
            ViewResult result = (ViewResult)controller.Contact();
            string msg = (string)result.ViewData["Message"];
            Assert.Equal("Your contact page.", msg);
        }



        [Fact(DisplayName ="ExceptionTest")]
        public void ProductError()
        {
            Assert.Throws<NullReferenceException>(()=> {
                controller.ProductPage(1000);
            });
        }
        

        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public void TestWithDifferentValues(int id)
        {
            ViewResult result = (ViewResult)controller.GetProduct(id);
            Assert.IsType<Product>(result.Model);
        }
    }
}
