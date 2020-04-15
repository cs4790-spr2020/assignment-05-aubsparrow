using System.Collections;
using BlabberApp.Services;
using BlabberApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class BlabServiceTest
    {
        private BlabFactory factory;
        private BlabService service;
        private string message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
        private string email = "foobar@example.com";

        [TestInitialize]
        public void Setup()
        {
            factory = new BlabFactory();
            service = (BlabService)factory.CreateBlabService();
        }
        [TestMethod]
        public void TetNewBlab()
        {
            //user hasn't been created yet
            Blab blab = service.CreateBlab(message, email);
            User newUser = new User(email);
            Assert.AreNotEqual(newUser.Id, blab.user.Id);
            
        }

        [TestMethod]
        public void TestNewBLabExistingUser()
        {
            User newUser = new User(email);
            //user already exists, should be equal
            service.userAdapter.Add(newUser);
            Blab blab = service.CreateBlab(message, email);
            Assert.AreEqual(newUser.Id, blab.user.Id);
        }

        [TestMethod]
        public void TestNewBlabGetAll()
        {
            User newUser = new User(email);
            Blab newblab = new Blab(message, newUser);
            service.NewBlab(newblab);
            CollectionAssert.Contains((ArrayList)service.GetAll(), newblab);

        }
        
    }
}