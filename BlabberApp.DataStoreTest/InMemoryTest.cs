using System.Collections;
using BlabberApp.Domain;
using BlabberApp.DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest

{
    [TestClass]
    public class InMemoryTest
    {

        private User newUser;
        private UserAdapter userAdapterHarness;
        private readonly string userEmail = "foobar@example.com";
        private BlabAdapter blabAdapterHarness;
        private Blab newBlab;
        private string message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";


        [TestInitialize]
        public void Setup()
        {
            newUser = new User(userEmail);
            userAdapterHarness = new UserAdapter(new InMemory());
            blabAdapterHarness = new BlabAdapter(new InMemory(), new InMemory());
            newBlab = new Blab(message, newUser);
        }

        [TestCleanup]
        public void Cleanup()
        {
            userAdapterHarness.Delete(newUser);
        }

        [TestMethod]
        public void TestAddAndGetByID()
        {
            userAdapterHarness.Add(newUser);
            User actual = userAdapterHarness.GetById(newUser.Id);
            Assert.AreEqual(newUser.Id, actual.Id);
        }

        [TestMethod]
        public void TestGetAll()
        {
            userAdapterHarness.Add(newUser);
            var list = (ArrayList)userAdapterHarness.GetAll();
            foreach(User user in list){
                if(newUser == user)
                {
                    Assert.AreEqual(newUser.Id, user.Id);
                }
            }
        }

        [TestMethod]
        public void TestGetUserByID()
        {
            userAdapterHarness.Add(newUser);
            User expectedUser = userAdapterHarness.GetById(newUser.Id);
            Assert.AreEqual(newUser.Id, expectedUser.Id);
        }

        [TestMethod]
        public void TestGetUserByEmail()
        {
            userAdapterHarness.Add(newUser);
            Assert.AreEqual(newUser, userAdapterHarness.GetUserByEmail(userEmail));
        }

        [TestMethod]
        public void TestDelete()
        {
            userAdapterHarness.Add(newUser);
            userAdapterHarness.Delete(newUser);
            CollectionAssert.DoesNotContain((ArrayList)userAdapterHarness.GetAll(), newUser.Id);
        }

        [TestMethod]
        public void TestGetBlabsByUserEmail()
        {
            blabAdapterHarness.Add(newBlab);
            ArrayList listBlabs = (ArrayList)blabAdapterHarness.GetByEmail(newUser.Email);
            CollectionAssert.Contains(listBlabs, newBlab);
        }

        [TestMethod]
        public void TestNewBlab()
        {
            Blab newBlab = new Blab(message + " 2");
            blabAdapterHarness.Add(newBlab);
            Assert.AreEqual(newBlab.Id, blabAdapterHarness.GetById(newBlab).Id);
        }
    }
}
