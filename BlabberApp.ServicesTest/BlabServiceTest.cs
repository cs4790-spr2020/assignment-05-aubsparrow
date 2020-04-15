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
            service.NewBlab(message, email );
            
        }
    }
}