using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationTesting.Controllers;
using WebApplicationTesting.Models;

namespace UnitTestProject1
{
    [TestClass]
   public class ProductTest
    {
        [TestMethod]
        public void IndexTestMethod()
        {
            //Arrange
            // mocking the missing class.....productstoremock is the class name(say)...
            Mock<IProductStore> productstoremock = new Mock<IProductStore>();

            //mockproductstore is the mocked Object........
            IProductStore mockproductstore = productstoremock.Object;

            //for method implementation of the mocked class i.e. mocking the method FindProduct......
            productstoremock.Setup(c => c.FindProduct(It.IsAny<int>())).Returns(true);

            ProductController controller = new ProductController(mockproductstore);
            ViewResult result = (ViewResult)controller.Index();
            Assert.IsTrue((bool)result.Model);

            //For the verification whtr the fn is executed once or not....
            productstoremock.Verify(c => c.FindProduct(100));
        }

    }
}
