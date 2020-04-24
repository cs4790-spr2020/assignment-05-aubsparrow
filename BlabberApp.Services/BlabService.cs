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
            if(user == null)
            {
                user = new User(email);
                userAdapter.Add(user);
                return new Blab(msg, user);
            }
            return new Blab(msg, user);
            
        }
    }
}