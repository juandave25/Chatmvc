using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chatmvc.Models;
using Chatmvc.Repository;
using Chatmvc.Hubs;

namespace Chatmvc.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository UserRepository;
        IMessageRepository MessageRepository;
        IChatHub chatHub;

        public HomeController() { }

        public HomeController(IUserRepository _UserRepository, IChatHub _chatHub, IMessageRepository _MessageRepository)
        {
            this.UserRepository = _UserRepository;
            this.chatHub = _chatHub;
            this.MessageRepository = _MessageRepository;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<Message> messages = new List<Message>();
            messages = MessageRepository.Get();
            return Json(messages, JsonRequestBehavior.AllowGet);
            
        }

    }
}