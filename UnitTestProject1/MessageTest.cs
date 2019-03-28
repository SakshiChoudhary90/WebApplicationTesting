using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationTesting.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class MessageTest
    {
        static Mock<IMessage> mockemailclass;
        static IMessage obj;
        static MessagingService service;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            mockemailclass = new Mock<IMessage>();
            obj = mockemailclass.Object;
            service = new MessagingService(obj);
        }
        [TestMethod]
        public void MessageTest1()
        {
            mockemailclass.Setup(c => c.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            bool result = service.SendMessage("a", "b", "Helloo");
            Assert.IsTrue(result);

            mockemailclass.SetupProperty(c => c.sender, "abc@abc.com");
            mockemailclass.SetupProperty(c => c.receiver, "xyz@xyz.com");
            mockemailclass.SetupProperty(c => c.message, "Helloo Jackson");

            mockemailclass.Setup(c => c.SendMessage()).Returns(true);

            //this SendMessage() is the mocked class method....
            result = service.SendMessage();
            Assert.IsTrue(result);


            Assert.AreEqual(service.message.message, "Helloo Jackson");
            Assert.AreEqual(service.message.sender, "abc@abc.com");

            mockemailclass.Verify(c => c.SendMessage());
        }
    }
}
