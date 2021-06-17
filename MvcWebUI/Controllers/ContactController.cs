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
    [Authorize]
    public class ContactController : Controller
    {
        ContactManager _conmg = new ContactManager(new EfContactDAL());
        MessageManager _msgman = new MessageManager(new EfMessageDAL());
        ContactValidator _conval = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            return View(_conmg.GetList());
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalue = _conmg.GetByID(id);
            return View(contactvalue);
        }
        public PartialViewResult _MessageSideBar()
        {
            ViewBag.ContactCount = _conmg.Count();
            ViewBag.MessageCount = _msgman.Count();
            return PartialView();
        }
    }
}