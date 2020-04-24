using System.Collections;
using BlabberApp.Domain;

namespace BlabberApp.Services
{
    public interface IBlabService
    {
       void NewBlab(Blab blab);
       IEnumerable GetAll(); 
       Blab CreateBlab(string message, string email);
    }
}