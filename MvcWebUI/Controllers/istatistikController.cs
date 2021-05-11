using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class istatistikController : Controller
    {
        Context ctx = new Context();
        CategoryManager _cm = new CategoryManager(new EfCategoryDAL());
        HeadingManager _hm = new HeadingManager(new EfHeadingDAL());
        WriterManager _wm = new WriterManager(new EfWriterDAL());
        // GET: istatistik
        public ActionResult Index()
        {
            
            ViewBag.CategoryCount = _cm.Count();            
            var catidval = _cm.GetIDByName("Yazılım");
            ViewBag.HeadingCount = _hm.Count(x => x.CategoryID == catidval);
            ViewBag.WriterCount = _wm.Count(x => x.WriterName.Contains("a"));
            var maxcatid = _hm.MaxID(x => x.CategoryID);
            ViewBag.MostPopularCategory = _cm.GetByID(maxcatid).CategoryName;
            var truecat = _cm.Count(x => x.CategoryStatus == true);
            var falsecat = _cm.Count(x => x.CategoryStatus == false);
            int sonuc=0;
            string mesaj = "";
            if (truecat>=falsecat)
            {
                sonuc = truecat - falsecat;               
            }
            else
            {
                sonuc = falsecat - truecat;
            }
            ViewBag.Categorytruefalsefark = sonuc;
            
            return View();
        }
    }
}