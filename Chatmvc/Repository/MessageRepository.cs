using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chatmvc.Models;

namespace Chatmvc.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public void Add(Message message)
        {
            using (var context = new Context())
            {
                context.Message.Add(message);
                context.SaveChanges();
            }
        }

        public List<Message> Get()
        {
            var messages = new List<Message>();
            using (var context = new Context())
            {
                messages= context.Message.ToList();
                
            }

            return messages;
        }
    }
}