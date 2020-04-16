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
           this.Id = Guid.NewGuid();
           this.user = new User();
           this.Message = "";
           this.DateTime = DateTime.Now;
       }

       public Blab(string Message)
       {
           this.Id = Guid.NewGuid();
           this.user = new User();
           this.Message = Message;
           this.DateTime = DateTime.Now;
       }

      
        public Blab(string message, User user)
        {
            this.Id = Guid.NewGuid();
            this.user = user;
            this.Message = message;
            this.DateTime = DateTime.Now;
        }
    }
}