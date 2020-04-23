using System.Collections;
using BlabberApp.Domain;

namespace BlabberApp.Services
{
    public interface IUserService
    {
        IEnumerable GetAllUsers();
        void AddNewUser(string email);
        User CreateUser(string email);
    }
}