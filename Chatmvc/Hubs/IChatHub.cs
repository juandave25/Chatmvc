using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatmvc.Hubs
{
    public interface IChatHub
    {
        void NotifyToAllClients();

        void Connect(string userName);

        void Send(string message);

        Task OnDisconnected(bool stopCalled);
    }
}
