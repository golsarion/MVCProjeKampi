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
    public class GalleryController : Controller
    {
        ImageFileManager _ifm = new ImageFileManager(new EfImageFileDAL());
        // GET: Gallery
        public ActionResult Index()
        {
            return View(_ifm.GetList());
        }
    }
}