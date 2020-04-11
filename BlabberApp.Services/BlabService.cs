using System;
using System.Collections;
using BlabberApp.DataStore;
using BlabberApp.Domain;

namespace BlabberApp.Services
{
    public class BlabService : IBlabService
    {
        private readonly BlabAdapter BlabAdapter;
        public void NewBlab(string message, string email)
        {
            BlabAdapter.Add(CreateBlab(message, email));
        }
        public void NewBlab(Blab blab)
        {
            BlabAdapter.Add(blab);
        }
        public BlabService(BlabAdapter adapter)
        {
            BlabAdapter = adapter;
        }

        public IEnumerable GetAll()
        {
            return BlabAdapter.GetAll();
        }
        public IEnumerable GetUserBlabs(string email)
        {
            return null;
        }

        public Blab CreateBlab(string msg, string email)
        {
            User user = new User(email);
            return new Blab(msg, user);
        }
    }
}