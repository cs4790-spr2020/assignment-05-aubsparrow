using System;
using System.Collections;
using BlabberApp.DataStore;
using BlabberApp.Domain;

namespace BlabberApp.Services
{
    public class BlabService : IBlabService
    {
        private readonly BlabAdapter BlabAdapter;
        public UserAdapter userAdapter;
        public BlabService(BlabAdapter adapter, UserAdapter userAdapter)
        {
            BlabAdapter = adapter;
            this.userAdapter = userAdapter;
        }
        public void NewBlab(string message, string email)
        {
            BlabAdapter.Add(CreateBlab(message, email));
        }
        public void NewBlab(Blab blab)
        {
            BlabAdapter.Add(blab);
        }
        public IEnumerable GetAll()
        {
            return BlabAdapter.GetAll();
        }

        public Blab CreateBlab(string msg, string email)
        {
            User user = userAdapter.GetUserByEmail(email);
            //error scenario - user doesn't exist
            if(user == null)
            {
                User newUser = new User(email);
                userAdapter.Add(newUser);
                return new Blab(msg, newUser);
            }
            else
            {
                return new Blab(msg, user);
            }
            
        }
    }
}