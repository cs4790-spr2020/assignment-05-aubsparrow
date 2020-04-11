using System.Collections;
using BlabberApp.Domain;

namespace BlabberApp.Services
{
    public interface IBlabService
    {
       void NewBlab(string message, string email);
       void NewBlab(Blab blab);
       IEnumerable GetUserBlabs(string email);
       IEnumerable GetAll(); 
    }
}