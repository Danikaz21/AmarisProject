using AmarisTest.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AmarisUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetEmployee()
        {
                var controller = new EmployeeController();
                var result = controller.GetEmployee("1");
                Assert.AreEqual(true, result.AsyncState);
        }

        [TestMethod]
        public void TestEmployees()
        {
            var controller = new EmployeeController();
            var result = controller.Employee();
            Assert.AreEqual(true, result.AsyncState);
        }
    }
}
    

