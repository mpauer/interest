using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using movement;

namespace TestInterest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Movement[] TestMovement = new Movement[2];

            TestMovement[0] = new Movement();
            TestMovement[0].type = "D";
            TestMovement[0].value = 100.0F;
            TestMovement[0].when = DateTime.Today.AddDays(-365);

            TestMovement[1] = new Movement();
            TestMovement[1].type = "B";
            TestMovement[1].value = 100.0F;
            TestMovement[1].when = DateTime.Today;

            Movement myResult = new Movement(); //???
            float result = myResult.result(TestMovement, TestMovement.Length);

            Assert.AreEqual(0, result, "Result is different from expected.");
        }
    }
}

