using System.Collections;
using BlabberApp.Domain;
using BlabberApp.DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserSQLTest
    {
        private User user;
        private User user2;
        private UserAdapter adapterHarness;
        private readonly string userEmail = "foobar@example.com";
        private readonly string user2Email = "foobar2@example.com";
        private bool secondUserAdded = false;

        [TestInitialize]
        public void Setup()
        {
            user = new User(userEmail);
            adapterHarness = new UserAdapter(new SqlUser());
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            adapterHarness.Delete(user);
            
        }
        
        [TestMethod]
        public void TestNewAndGetUser()
        {
            adapterHarness.Add(user);
            User actual = adapterHarness.GetById(user.Id);
            Assert.AreEqual(user.Id, actual.Id);
        }

        [TestMethod]
        public void TestGetAll()
        {
            adapterHarness.Add(user);
            var UserList = (ArrayList)adapterHarness.GetAll();
            foreach(User user in UserList){
                if(user == this.user)
                {
                    Assert.AreEqual(user, this.user);
                }
            }
        }

        [TestMethod]
        public void TestGetByEmail()
        {
            adapterHarness.Add(user);
            User actual = adapterHarness.GetUserByEmail(user.Email);
            Assert.AreEqual(user.Id, actual.Id);
        }

        [TestMethod]
        public void TestDelete()
        {
            adapterHarness.Add(user);
            adapterHarness.Delete(user);
            CollectionAssert.DoesNotContain((ArrayList)adapterHarness.GetAll(), user);
        }

        public void TestChangeUserEmail()
        {
            User user = new User();
            user.ChangeEmail("foobar5@example.com");
            adapterHarness.Add(user);
            Assert.AreEqual(user.Email, adapterHarness.GetById(user.Id).Email);
        }

        
    }
}