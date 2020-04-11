using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain;

namespace BlabberApp.DomainTest
{
    [TestClass]
    public class BlabTest
    {
        [TestMethod]
        public void TestSetGetMessage()
        {
            //arrange
            Blab harness = new Blab();
            string expected = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            harness.Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            //act
            string actual = harness.Message;
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestSetGetUserId()
        {
            //arrange
            Blab harness = new Blab();
            string expected = "foobar@example.com";
            harness.UserID = "foobar@example.com";
            //Act
            string actual = harness.UserID;
            Assert.AreEqual(actual, expected);
         }

        [TestMethod]
        public void TestGetSysId()
        {
            Blab harness = new Blab();
            string expected = harness.getSysId();
            //act & assert
            string actual = harness.getSysId();
            Assert.AreEqual(actual, expected);
            Assert.IsInstanceOfType(harness.getSysId(), typeof(string));
        }

    }
}
