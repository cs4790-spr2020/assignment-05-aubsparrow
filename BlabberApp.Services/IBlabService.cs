using System.Collections;
using BlabberApp.Domain;

namespace BlabberApp.Services
{
    public interface IBlabService
    {
       void NewBlab(string message, string email);
       void NewBlab(Blab blab);
       IEnumerable GetAll(); 
       Blab CreateBlab(string message, string email);
       Blab CreateBlab(string message, User user);
    }
}