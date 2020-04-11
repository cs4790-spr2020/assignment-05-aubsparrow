using BlabberApp.DataStore;

namespace BlabberApp.Services
{
    public class BlabFactory
    {
        public BlabAdapter CreateBlabAdapter(IBlabPlugin plugin = null)
        {
            if(plugin == null)
            {
                plugin = this.CreateBlabPlugin();
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
            }

            return new BlabService(adpater);
        }
    }
}