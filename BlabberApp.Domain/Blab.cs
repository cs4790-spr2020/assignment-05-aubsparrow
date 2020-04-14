using System;

namespace BlabberApp.Domain
{
    public class Blab : IDatum
    {
       public Guid Id{get; set;}
       public DateTime DateTime{get; set;}
       public string Message {get; set;}
       public User user {get; set;}


       public Blab()
       {
           this.user = new User();
           this.Message = "";
           this.DateTime = DateTime.Now;
       }

       public Blab(string Message)
       {
           this.user = new User();
           this.Message = Message;
           this.DateTime = DateTime.Now;
       }

       public Blab(User user)
        {
            this.user = user;
            this.Message = "";
            this.DateTime = DateTime.Now;
        }

        public Blab(string message, User user)
        {
            this.user = user;
            this.Message = message;
            this.DateTime = DateTime.Now;
        }
    }
}