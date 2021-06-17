using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class WriterSkillsController : Controller
    {
        WriterSkillManager _wsm = new WriterSkillManager(new EfWriterSkillDAL());
        WriterManager _wm = new WriterManager(new EfWriterDAL());
        // GET: WriterSkills
        public ActionResult Index(string p)
        {
            int id = 0;
            if (string.IsNullOrEmpty((string)Session["WriterMail"]))
            {
                return RedirectToAction("WriterLogin", "Login");
            }
            else
            {
                p = (string)Session["WriterMail"];
                id = _wm.GetWriterByUsername(p).WriterID;
                ViewBag.SkillList = _wsm.GetWriterSkills(id);
                return View(_wm.GetByID(id));
            }
            
            
        }
    }
}