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
        IChatHub chatHub;

        public HomeController() { }

        public HomeController(IUserRepository _UserRepository, IChatHub _chatHub)
        {
            UserRepository = _UserRepository;
            chatHub = _chatHub;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(User user)
        {
            if(UserRepository.getById(user.nickname).Count > 0) {
                return Json("nickname already exist",JsonRequestBehavior.AllowGet);
            }
            else
            {
                UserRepository.add(user);
                Json("nickname already exist", JsonRequestBehavior.AllowGet);
                chatHub.NotifyToAllClients();
                return RedirectToAction("Index");
            }
            
        }

    }
}