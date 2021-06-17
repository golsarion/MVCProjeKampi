using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class WriterMessageController : Controller
    {
        MessageManager _msgman = new MessageManager(new EfMessageDAL());
        MessageValidator msgval = new MessageValidator();
        // GET: WriterMessage
        public ActionResult Inbox(int id=0)
        {
            id = 3;
            var messagelist = _msgman.GetListInbox();
            return View(messagelist);
        }
        public PartialViewResult _MessageSideBar()
        {           
            ViewBag.ReceiveCount = _msgman.UnreadCount();
            ViewBag.SendCount = _msgman.SendCount();
            return PartialView();
        }
    }
}