using System;
using System.Collections;
using BlabberApp.Domain;

namespace BlabberApp.DataStore
{
    public class BlabAdapter
    {
        private IBlabPlugin blabPlugin;
        private IUserPlugin userPlugin;

        public BlabAdapter(IBlabPlugin plugin, IUserPlugin userPlugin)
        {
            blabPlugin = plugin;
            this.userPlugin = userPlugin;
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

        public IEnumerable GetByEmail(string email)
        {
            return blabPlugin.GetBlabsByEmail(email);
        }
    }
}