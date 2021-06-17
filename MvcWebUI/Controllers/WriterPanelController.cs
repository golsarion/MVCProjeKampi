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
    public class WriterPanelController : Controller
    {
        HeadingManager _hm = new HeadingManager(new EfHeadingDAL());
        CategoryManager _cm = new CategoryManager(new EfCategoryDAL());
        WriterManager _wm = new WriterManager(new EfWriterDAL());
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading(string p)
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
                ViewBag.Writer = _wm.GetWriterByUsername(p);
                return View(_hm.GetListByWriter(id));
            }
            
        }
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in _cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.CategoryList = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = (int)Session["WriterID"];
            heading.HeadingStatus = true;
            _hm.Add(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuesCategory = (from x in _cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                       Selected = false
                                                   }).ToList();
            ViewBag.Categories = valuesCategory;
            return View(_hm.GetByID(id));
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            p.HeadingStatus = true;
            _hm.Update(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = _hm.GetByID(id);
            _hm.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult RestoreHeading(int id)
        {
            _hm.Restore(id);
            return RedirectToAction("MyHeading");
        }
    }
}