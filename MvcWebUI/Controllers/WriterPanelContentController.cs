using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager _cm = new ContentManager(new EfContentDAL());
        WriterManager _wm = new WriterManager(new EfWriterDAL());
        // GET: WriterPanelContent
        public ActionResult MyContents(string p)
        {
            int id = 0;            
            p = (string)Session["WriterMail"];
            id = _wm.GetWriterByUsername(p).WriterID;
            ViewBag.Writer = _wm.GetWriterByUsername(p);
            return View(_cm.GetContentsByWriterID(id));
        }
    }
}