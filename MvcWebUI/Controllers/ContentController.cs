using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        ContentManager _cm = new ContentManager(new EfContentDAL());
        HeadingManager _hm = new HeadingManager(new EfHeadingDAL());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            ViewBag.Heading = _hm.GetByID(id);
            return View(_cm.GetContentsByHeadingID(id));
        }
    }
}