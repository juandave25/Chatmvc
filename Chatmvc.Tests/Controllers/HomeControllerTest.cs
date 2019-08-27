using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chatmvc;
using Chatmvc.Controllers;
using Chatmvc.Repository;
using Chatmvc.Hubs;

namespace Chatmvc.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        IUserRepository userRepository;
        IMessageRepository messageRepository;
        IChatHub chatHub;

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(userRepository,chatHub,messageRepository);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
