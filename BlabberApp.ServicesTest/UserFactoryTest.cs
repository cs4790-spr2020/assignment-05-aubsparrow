using BlabberApp.Services;
using BlabberApp.DataStore;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class UserFactoryTest
    {
        private UserFactory factory;
        [TestInitialize]
        public void Setup()
        {
            factory = new UserFactory();
        }
        
        [TestMethod]
        public void TestCreateAdapter()
        {
            UserAdapter adapter = factory.CreateUserAdapter();
            Assert.IsTrue(adapter is UserAdapter);
        }

        [TestMethod]
        public void TestCreateSqlUserPlugin()
        {
            IPlugin SqlService = factory.CreateUserPlugin("MySQL");
            Assert.IsTrue(SqlService is SqlUser);
        }

        [TestMethod]
        public void TestCreateInMemoryPlugin()
        {
            IPlugin InMemoryService = factory.CreateUserPlugin();
            Assert.IsTrue(InMemoryService is InMemory);
        }

        public void TestCreateUserService()
        {
            UserService UserService = factory.CreateUserService();
            Assert.IsTrue(UserService is UserService);
        }

    }
}