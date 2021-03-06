﻿using System;
using System.Collections;
using BlabberApp.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlabberApp.DataStore
{
    public class InMemory : IBlabPlugin, IUserPlugin
    {
        private ArrayList lstBuffer;
        public InMemory()
        {
            lstBuffer = new ArrayList();
        }

        public void Create(IDatum obj)
        {
            lstBuffer.Add(obj);
        }

        public IEnumerable ReadAll()
        {
            return lstBuffer;
        }

        public IDatum ReadById(Guid Id)
        {
            foreach(IDatum obj in lstBuffer)
            {
                if(Id.Equals(obj.Id))
                {
                    return obj;
                }
            }
            return null;
        }

         public IDatum GetById(Guid Id)
        {
            foreach(IDatum obj in lstBuffer)
            {
                if(Id.Equals(obj.Id))
                {
                    return obj;
                }
            }
            return null;
        }

        public User GetUserByEmail(string email)
        {
            foreach(User user in lstBuffer)
            {
                if(user.Email.Equals(email))
                {
                    return user;
                }
            }
            return null;
        }

        public IEnumerable GetBlabsByEmail(string email)
        {
            ArrayList userBlabs = new ArrayList();
            foreach(Blab blab in lstBuffer)
            {
                if(blab.user.Email.Equals(email))
                {
                    userBlabs.Add(blab);
                }
            }
            return userBlabs;
        }

        public void Delete(IDatum obj)
        {
            lstBuffer.Remove(obj);
        }

    }
    
}
