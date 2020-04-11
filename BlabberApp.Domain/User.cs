using System;
using System.Net.Mail;
using BlabberApp.Domain;

namespace BlabberApp.Domain
{
    public class User : IDatum
    {
        public Guid Id{get; set;}
        public DateTime RegisterDTTM{get; set;}
        public DateTime LastLoginDTTM{get; set;}
        public string Email {get; private set;}
        
        public User()
        {
            this.Id = Guid.NewGuid();
        }
        public User(string email)
        {
            this.Id = Guid.NewGuid();
            this.ChangeEmail(email);
            this.RegisterDTTM = DateTime.Now;
            this.LastLoginDTTM = DateTime.Now;
            

        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 50)
                throw new FormatException("Email Invalid");
            try
            {
                MailAddress m = new MailAddress(email); 
            }
            catch (FormatException)
            {
                throw new FormatException("Email Invalid");
            }
            Email = email;
        }
    }

}