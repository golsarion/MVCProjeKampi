using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _abm = new AboutManager(new EfAboutDAL());
        // GET: About
        public ActionResult Index()
        {
            return View(_abm.GetList());
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            _abm.Add(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}