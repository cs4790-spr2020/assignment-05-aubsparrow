using BlabberApp.Domain;

namespace BlabberApp.DataStore
{
    public interface IUserPlugin : IPlugin
    {
        User GetUserByEmail(string email);
    }
}