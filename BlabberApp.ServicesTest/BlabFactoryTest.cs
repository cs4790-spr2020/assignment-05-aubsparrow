using BlabberApp.Services;
using BlabberApp.Domain;
using BlabberApp.DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class BlabFactoryTest
    {
        private BlabFactory blabFactory;
        [TestInitialize]
        public void Setup()
        {
            blabFactory = new BlabFactory();
        }


        [TestMethod]
        public void CreateBlabAdapter()
        {
            BlabAdapter adapter = blabFactory.CreateBlabAdapter(); 
            Assert.IsTrue(adapter is BlabAdapter);
        }

        [TestMethod]
        public void CreateSqlBlab()
        {
            IBlabPlugin plugin = blabFactory.CreateBlabPlugin("MySQL");
            Assert.IsTrue(plugin is SqlBlab); 
        }

        [TestMethod]
        public void CreateInMemoryBlab()
        {
            IBlabPlugin plugin = blabFactory.CreateBlabPlugin();
            Assert.IsTrue(plugin is InMemory);
        }

        [TestMethod]
        public void TestCreateBlabService()
        {
            IBlabService service = blabFactory.CreateBlabService();
            Assert.IsTrue(service is BlabService);
        }

        [TestMethod]
        public void TestUseBlabAdapter()
        {
            BlabAdapter adapter = blabFactory.CreateBlabAdapter();
            Blab blab = new Blab("blab test", new User());
            adapter.Add(blab);
            CollectionAssert.Contains((ArrayList)adapter.GetAll(), blab);
        }

        [TestMethod]
        public void TestInMemoryBlabPluginAdd()
        {
            IBlabPlugin plugin = blabFactory.CreateBlabPlugin();
            Blab newBlab = new Blab("blab test", new User("foobar@example.com"));
            plugin.Create(newBlab);
            Assert.AreEqual(newBlab.Id, plugin.GetById(newBlab.Id).Id);
        }

        [TestMethod]
        public void TestSQLBlabPluginAdd()
        {
            IBlabPlugin plugin = blabFactory.CreateBlabPlugin("MySql");
            Blab newBlab = new Blab("blab test", new User("foobar@example.com"));
            plugin.Create(newBlab);
            Assert.AreEqual(newBlab.Id, plugin.GetById(newBlab.Id).Id);
        }

    }
}