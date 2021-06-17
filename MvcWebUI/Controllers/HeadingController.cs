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
    public class HeadingController : Controller
    {
        HeadingManager _hm = new HeadingManager(new EfHeadingDAL());
        WriterManager _wm = new WriterManager(new EfWriterDAL());
        CategoryManager _cm = new CategoryManager(new EfCategoryDAL());
        // GET: Heading
        public ActionResult Index()
        {
            var headingvalues = _hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuesCategory = (from x in _cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.CategoryName,
                                                       Value=x.CategoryID.ToString(),
                                                       Selected=false
                                                   }).ToList();
            ViewBag.CategoryList = valuesCategory;
            List<SelectListItem> valuesWriters = (from x in _wm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.WriterName+" "+x.WriterSurname,
                                                       Value = x.WriterID.ToString(),
                                                       Selected = false
                                                   }).ToList();
            ViewBag.WriterList = valuesWriters;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.HeadingStatus = true;
            _hm.Add(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
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
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue= _hm.GetByID(id);
            _hm.Delete(headingValue);
            return RedirectToAction("Index");
        }
        public ActionResult RestoreHeading(int id)
        {
            _hm.Restore(id);
            return RedirectToAction("Index");
        }
    }
}