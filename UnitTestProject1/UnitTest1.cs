using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebApplicationTesting.Controllers;
using WebApplicationTesting.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static HomeController controller;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            controller = new HomeController();
            context.WriteLine("Home Controller Instance Created");

        }
        [TestMethod]
        public void TestForIndexAction()
        {
            // Arrange.....
            HomeController controller = new HomeController();

            // ..... Act....
            IActionResult result = controller.Index();
            ViewResult view = (ViewResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("HomeTests")]
        public void TestForContact()
        {
            //Arrange.....

            //Act.............
            IActionResult result = controller.Contact();
            ViewResult view = (ViewResult)result;
            string testString = "Your contact page.";
            string data = (string)view.ViewData["Message"];

            //Assert

            Assert.AreEqual(testString, data);
        }

        [TestMethod]
        [TestCategory("HomeTests")]
        public void TestForAllProducts()
        {
            //Arrange

            //Act
            ViewResult result = (ViewResult)controller.GetProducts();
            Assert.IsInstanceOfType(result.Model, typeof(List<Product>));
            // for only View we use "result", but for the model we use ".Models"
        }

        [TestMethod]
        [TestCategory("GetProductTest")]
        public void GetProductIfTest()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)controller.GetProduct(100);

            //Assert
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Product));
            Product product = (Product)result.Model;
            Assert.AreEqual(product.Title, "Pen");
        }


        [TestMethod]
        [TestCategory("GetProductTest")]
        public void GetProductElseTest()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)controller.GetProduct(300);

            //Assert
            //Assert.IsInstanceOfType(result.ViewName,typeof(string));
            Assert.AreEqual("Index", result.ViewName);
            
        }
        [TestMethod]
        [TestCategory("GetProductTest")]
        [ExpectedException(typeof(NullReferenceException))]
        public void ProductPageTest()
        {
            //Arrange

            //Act
            ViewResult result = controller.ProductPage(300);
        }
        [TestMethod]
        [DataRow(100)]
        [DataRow(101)]
        [DataRow(102)]
        public void IndividualProductTest(int id)
        {
            //Act
            ViewResult result = (ViewResult)controller.GetProduct(id);
            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(Product));
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
             
        }

    }

}
