using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        MessageManager _msgman = new MessageManager(new EfMessageDAL());
        ContactManager _contman = new ContactManager(new EfContactDAL());
        MessageValidator msgval = new MessageValidator();

        // GET: Message
        public ActionResult Inbox()
        {
            var messagelist = _msgman.GetListInbox();
            return View(messagelist);
        }
        public PartialViewResult _MessageSideBar()
        {
            ViewBag.ContactCount = _contman.Count();
            ViewBag.ReceiveCount = _msgman.UnreadCount();
            ViewBag.SendCount = _msgman.SendCount();
            return PartialView();
        }
        public ActionResult SendBox()
        {
            return View(_msgman.GetListSendBox());
        }
        [HttpGet]
        public ActionResult Compose()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Compose(Message message)
        {
            ValidationResult result = msgval.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Now;
                _msgman.Add(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MessageDetail(int id)
        {
            var messagedetail = _msgman.GetByID(id);
            messagedetail.MessageisRead = true;
            _msgman.Read(messagedetail);
            return View(messagedetail);
        }

    }
}