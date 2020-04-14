using System.Collections;

namespace BlabberApp.DataStore
{
    public interface IBlabPlugin : IPlugin
    {
        IEnumerable ReadByUserId(string Id);
        
    }
}