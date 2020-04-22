using System.Collections;
using BlabberApp.Domain;
using BlabberApp.DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabSQLTest
    {
        private string userEmail = "test@example.com";
        private User newUser;
        private Blab newBlab;
        private BlabAdapter adapter;
        private UserAdapter userAdapter;
        private string blabMessage = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
    
        [TestInitialize]
        public void Setup()
        {
            newUser = new User(userEmail);
            newBlab = new Blab(blabMessage, newUser);
            adapter = new BlabAdapter(new SqlBlab(), new SqlUser());
            userAdapter = new UserAdapter(new SqlUser());
            
        }

        [TestCleanup]
        public void Teardown()
        {
            adapter.Delete(newBlab);
        }

        [TestMethod]
        public void TestAddGetById()
        {
            adapter.Add(newBlab);
            Blab actual = adapter.GetById(newBlab);
            Assert.AreEqual(newBlab.Id, actual.Id);
        }

        [TestMethod]
        public void TestAddAndReadAll()
        {
            adapter.Add(newBlab);
            var BlabList = (ArrayList)adapter.GetAll();
            foreach(@Blab blab in BlabList)
            {
                if(blab.Id == newBlab.Id){
                    Assert.AreEqual(newBlab.Id, blab.Id);
                }
            }
        }

        [TestMethod]
        public void TestGetBlabsByEmail()
        {
            adapter.Add(newBlab);
            ArrayList blabList = (ArrayList)adapter.GetByEmail(userEmail);
            foreach(Blab blab in blabList)
            {
                if(blab == newBlab)
                {
                    Assert.AreEqual(blab.Id, newBlab.Id);
                }
            }
        }

        [TestMethod]
        public void TestNewBlabs()
        {
            Blab newBlab = new Blab();
            newBlab.Message = "test message";
            User user = new User(userEmail);
            newBlab.user = user;
            adapter.Add(newBlab);
            Assert.AreEqual(newBlab.Id, adapter.GetById(newBlab).Id);
        }
    }
}