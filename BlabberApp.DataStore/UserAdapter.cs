using System;
using System.Collections;
using BlabberApp.Domain;

namespace BlabberApp.DataStore
{
    public class UserAdapter
    {
        private readonly IPlugin UserPlugin;

        public UserAdapter(IPlugin plugin)
        {
            UserPlugin = plugin;
        }

        public void Add (User user)
        {
            UserPlugin.Create(user);
        }

        public IEnumerable GetAll()
        {
            return UserPlugin.ReadAll();
        }

        public User GetById(Guid Id)
        {
            return (User)UserPlugin.GetById(Id);
        }

        public void Delete(User user)
        {
            UserPlugin.Delete(user);
        }

        

    }


}