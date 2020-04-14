using System;
using System.Collections;
using BlabberApp.Domain;

namespace BlabberApp.DataStore
{
    public class BlabAdapter
    {
        private IBlabPlugin blabPlugin;

        public BlabAdapter(IBlabPlugin plugin)
        {
            blabPlugin = plugin;
        }

        public void Add(Blab blab)
        {
            blabPlugin.Create(blab);
        }

        public IEnumerable GetAll()
        {
            return this.blabPlugin.ReadAll();
        }

        public Blab GetById(Blab blab)
        {
            return (Blab)blabPlugin.GetById(blab.Id);
        }
        public void Delete(Blab blab)
        {
            blabPlugin.Delete(blab);
        }

        public IEnumerable GetByUserId(string email)
        {
            return blabPlugin.ReadByUserId(email);
        }
    }
}