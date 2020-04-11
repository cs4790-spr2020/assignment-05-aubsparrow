using System.Collections;
using System.Collections.Generic;
using BlabberApp.Domain;
using BlabberApp.DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;

namespace BlabberApp.DataStoreTest

{
    [TestClass]
    public class InMemoryTest
    {

        private User newUser;
        private UserAdapter adapterHarness;
        private readonly string userEmail = "foobar@example.com";

        [TestInitialize]
        public void Setup()
        {
            newUser = new User(userEmail);
            adapterHarness = new UserAdapter(new InMemory());
        }

        [TestCleanup]
        public void Cleanup()
        {
            adapterHarness.Delete(newUser);
        }

        [TestMethod]
        public void TestAddAndGetByID()
        {
            adapterHarness.Add(newUser);
            User actual = adapterHarness.GetById(newUser.Id);
            Assert.AreEqual(newUser.Id, actual.Id);
        }

        [TestMethod]
        public void TestGetAll()
        {
            adapterHarness.Add(newUser);
            var list = (ArrayList)adapterHarness.GetAll();
            foreach(User user in list){
                if(newUser == user)
                {
                    Assert.AreEqual(newUser.Id, user.Id);
                }
            }
        }

    }
}
