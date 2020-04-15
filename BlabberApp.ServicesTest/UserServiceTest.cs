using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Services; 

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class UserServiceTest
    {
        private UserFactory factory;
        [TestInitialize]
        public void Setup()
        {
            factory = new UserFactory();
        }
        [TestMethod]
        public void TestGetAllUsers()
        {
            //Arrange
            UserService userService = factory.CreateUserService();
            ArrayList expected = new ArrayList();
            //Act
            IEnumerable actual = userService.GetAllUsers();
            //Assert
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }   
    }
}