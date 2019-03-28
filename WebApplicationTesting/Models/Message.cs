using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTesting.Models
{
    public interface IMessage
    {
        string sender { get; set; }
        string receiver { get; set; }
        string message { get; set; }
        bool SendMessage();
        bool SendMessage(string sender, string receiver, string message);
    }

    public class MessagingService
    {
        public IMessage message;

        public MessagingService(IMessage message)
        {
            this.message = message;
        }
        public bool SendMessage()
        {
            return message.SendMessage();
        }

        public bool SendMessage(string s, string r, string m)
        {
            return message.SendMessage(s,r,m);
        }

    }
  /*  public class SMS : IMessage
    {
    }
    public class Email : IMessage {} 
    */



}
