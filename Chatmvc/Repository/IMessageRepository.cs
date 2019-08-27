using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatmvc.Models;

namespace Chatmvc.Repository
{
    public interface IMessageRepository
    {
        void Add(Message message);

        List<Message> Get();
    }
}
