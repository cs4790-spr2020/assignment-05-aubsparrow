using BlabberApp.Services;
using BlabberApp.DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class BlabFactoryTest
    {
        private BlabFactory factory;
        [TestInitialize]
        public void Setup()
        {
            factory = new BlabFactory();
        }


        [TestMethod]
        public void CreateBlabAdapter()
        {
            BlabAdapter adapter = factory.CreateBlabAdapter(); 
            Assert.IsTrue(adapter is BlabAdapter);
        }

        [TestMethod]
        public void CreateSqlBlab()
        {
            IBlabPlugin plugin = factory.CreateBlabPlugin("MySQL");
            Assert.IsTrue(plugin is SqlBlab); 
        }

        [TestMethod]
        public void CreateInMemoryBlab()
        {
            IBlabPlugin plugin = factory.CreateBlabPlugin();
            Assert.IsTrue(plugin is InMemory);
        }

        [TestMethod]
        public void TestCreateBlabService()
        {
            IBlabService service = factory.CreateBlabService();
            Assert.IsTrue(service is BlabService);
        }
    }
}