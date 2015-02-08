using System;
using IntroToMobileAppDevelopment.WebService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroToMobileAppDevelopment.WebService.Tests.Controllers
{
    [TestClass]
    public class RandomNumberControllerTest
    {
        [TestMethod]
        public void Get()
        {
            var controller = new RandomNumberController();
            controller.Get();
        }
    }
}
