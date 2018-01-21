using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.Web.Models;

namespace Chat.Web.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ChatViewModel vm = new ChatViewModel();

            vm.Users = db.Users.ToList();
            vm.Messages = db.Messages.ToList();

            return View(vm);
        }
    }
}