using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain;

namespace BlabberApp.DomainTest
{
    [TestClass]
    public class BlabTest
    {
        private string message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";

        [TestMethod]
        public void TestSetGetMessage()
        {
            //arrange
            
            string expected = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            Blab harness = new Blab(expected);
            //act
            //assert
            Assert.AreEqual(expected, harness.Message);
        }

        [TestMethod]
        public void TestBlabGetUserId()
        {
            //arrange
            User blabUser = new User("foobar@example.com");
            Blab newBlab = new Blab(message, blabUser );
            Assert.AreEqual(blabUser.Id, newBlab.user.Id);
        }

        

    }
}
