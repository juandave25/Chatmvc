using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using Chatmvc.Repository;

[assembly:OwinStartup(typeof(Chatmvc.Models.startUp))]
namespace Chatmvc.Models
{

    public class startUp
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(typeof(Hubs.chatHub),() => new Hubs.chatHub(new UserRepository(),new RoomRepository(),new MessageRepository()));
            app.MapSignalR();
        }


    }
}