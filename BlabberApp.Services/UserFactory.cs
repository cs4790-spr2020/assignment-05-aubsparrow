using BlabberApp.DataStore;

namespace BlabberApp.Services
{
    public class UserFactory
    {
        public UserAdapter CreateUserAdapter(IPlugin plugin = null)
        {
            if (plugin == null)
            {
                plugin = this.CreateUserPlugin();
            }

            return new UserAdapter(plugin);
        }
        public IPlugin CreateUserPlugin(string type = "")
        {
            if (type.ToUpper().Equals("MYSQL"))
            {
                return new SqlUser();
            }

            return new InMemory();
        }

        public UserService CreateUserService(UserAdapter adapter = null)
        {
            if (adapter == null)
            {
                adapter = this.CreateUserAdapter();
            }

            return new UserService(adapter);
        }
    }
}