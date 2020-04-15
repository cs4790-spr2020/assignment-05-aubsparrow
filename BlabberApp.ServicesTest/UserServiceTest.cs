using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Services; 
using BlabberApp.Domain;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class UserServiceTest
    {
        private UserFactory factory;
        private UserService service;
        private string email = "foobar@example.com";

        [TestInitialize]
        public void Setup()
        {
            factory = new UserFactory();
            service = factory.CreateUserService();
        }
        [TestMethod]
        public void TestGetAllUsers()
        {
            ArrayList expected = new ArrayList();
            ArrayList actual = (ArrayList)service.GetAllUsers();
            Assert.AreEqual(expected.Count, actual.Count);
        } 

        [TestMethod]
        public void TestAddNewUser()
        {
            service.AddNewUser(email);
            ArrayList allUsers =(ArrayList) service.GetAllUsers();
            foreach(User user in allUsers)
            {
                if(user.Email == email)
                {
                    Assert.AreEqual(email, user.Email);
                }
            }
        }

        [TestMethod]
        public void TestCreateUser()
        {
            service.CreateUser(email);
            ArrayList allUsers = (ArrayList)service.GetAllUsers();
            foreach(User user in allUsers)
            {
                if(user.Email == email)
                {
                    Assert.AreEqual(email, user.Email);
                }
            }
        }  
    }
}