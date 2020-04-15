using System.Collections;

namespace BlabberApp.DataStore
{
    public interface IBlabPlugin : IPlugin
    {
        IEnumerable GetBlabsByEmail(string email);
        
    }
}