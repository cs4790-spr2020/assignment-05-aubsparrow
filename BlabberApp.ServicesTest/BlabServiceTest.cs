using System.Collections;
using BlabberApp.Services;
using BlabberApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class BlabServiceTest
    {
        private BlabFactory blabFactory;
        private UserFactory userFactory;
        private BlabService service;
        private string message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
        private string email = "foobar@example.com";

        [TestInitialize]
        public void Setup()
        {
            blabFactory = new BlabFactory();
            userFactory = new UserFactory();
            service = (BlabService)blabFactory.CreateBlabService();
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
        
        [TestMethod]
        public void TestGetEmail()
        {
            User newUser = new User(email);
            Blab newBlab = new Blab(message, newUser);
            service.NewBlab(newBlab);
            ArrayList listBlabs = (ArrayList)service.GetAll();
            Assert.AreEqual(newUser.Email, newBlab.user.Email);
        }

        [TestMethod]
        public void TestAdapters()
        {
            SqlUser userPlugin = new SqlUser();
            BlabAdapter bAdapter = blabFactory.CreateBlabAdapter(new SqlBlab(), userPlugin);
            UserAdapter uAdapter = userFactory.CreateUserAdapter(userPlugin);
            BlabService service = new BlabService(bAdapter, uAdapter);

            Blab newBlab = service.CreateBlab(message, email);
            service.NewBlab(newBlab);
            Blab expectedBlab = bAdapter.GetById(newBlab);
            Assert.AreEqual(expectedBlab.Id, newBlab.Id);
           
            bAdapter.Delete(newBlab);
            uAdapter.Delete(uAdapter.GetUserByEmail(email));
            CollectionAssert.DoesNotContain((ArrayList)bAdapter.GetAll(), newBlab);
            CollectionAssert.DoesNotContain((ArrayList)uAdapter.GetAll(), uAdapter.GetUserByEmail(email));
            
            
        }
    }
}