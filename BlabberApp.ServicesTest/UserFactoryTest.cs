using BlabberApp.Services;
using BlabberApp.Domain;
using BlabberApp.DataStore;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class UserFactoryTest
    {
        private UserFactory factory;
        private User newUser;
        private string email = "foobar@example.com";
        [TestInitialize]
        public void Setup()
        {
            factory = new UserFactory();
            newUser = new User(email);
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

        [TestMethod]
        public void TestCreateUserService()
        {
            UserService UserService = factory.CreateUserService();
            Assert.IsTrue(UserService is UserService);
        }

        [TestMethod]
        public void TestUsingAdapter()
        {
            UserAdapter adapter = factory.CreateUserAdapter();
            User newUser = new User();
            newUser.ChangeEmail("foobar@example.com");
            adapter.Add(newUser);
            Assert.AreEqual(newUser.Id, adapter.GetUserByEmail("foobar@example.com").Id);
            
        }
        
        [TestMethod]
        public void TestUsingAdapater01()
        {
            UserAdapter adapter = factory.CreateUserAdapter();
            User newUser = new User("foobar@example.com");
            adapter.Add(newUser);
            Assert.AreEqual(newUser.Id, adapter.GetById(newUser.Id).Id);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            UserAdapter adapter = factory.CreateUserAdapter(new SqlUser());
            adapter.Add(newUser);
            adapter.Delete(newUser);
            CollectionAssert.DoesNotContain((ArrayList)adapter.GetAll(), newUser);
        }

       

        
    }
}