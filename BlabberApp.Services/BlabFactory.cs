using BlabberApp.DataStore;

namespace BlabberApp.Services
{
    public class BlabFactory
    {
        private UserFactory userFactory = new UserFactory();
        private IUserPlugin userPlugin;
        private UserAdapter userAdapter;
        public BlabAdapter CreateBlabAdapter(IBlabPlugin plugin = null)
        {
            if(plugin == null)
            {
                plugin = this.CreateBlabPlugin();
                userPlugin = userFactory.CreateUserPlugin();
                
            }
            return new BlabAdapter(plugin);
        }

        public IBlabPlugin CreateBlabPlugin(string type = "")
        {
            if(type.ToUpper().Equals("MYSQL"))
            {
                return new SqlBlab();
            }
            else
            {
                return new InMemory();
            }
        }

        public IBlabService CreateBlabService(BlabAdapter adpater = null)
        {
            
            if(adpater == null)
            {
                adpater = this.CreateBlabAdapter();
                userAdapter = userFactory.CreateUserAdapter();
            }

            return new BlabService(adpater, userAdapter);
        }
    }
}