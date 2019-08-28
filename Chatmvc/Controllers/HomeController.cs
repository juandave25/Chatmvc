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
        private IMessageRepository MessageRepository;
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {
            MessageRepository = new MessageRepository();
            List<Message> messages = new List<Message>();
            messages = MessageRepository.Get();
            return Json(messages, JsonRequestBehavior.AllowGet);
            
        }

    }
}