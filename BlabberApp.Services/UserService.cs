using System;
using System.Collections;
using BlabberApp.DataStore;
using BlabberApp.Domain;

namespace BlabberApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserAdapter userAdapter;

        public UserService(UserAdapter adapter)
        {
            userAdapter = adapter;
        }

        public IEnumerable GetAllUsers()
        {
            return userAdapter.GetAll();
        }

        public void AddNewUser(string email)
        {
            try
            {
                userAdapter.Add(CreateUser(email));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.ToString());
            }
        }

        public User CreateUser(string email)
        {
            return new User(email);
        }
 
    }
}