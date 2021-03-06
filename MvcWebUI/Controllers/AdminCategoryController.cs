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
    [Authorize(Roles ="A")]
    public class AdminCategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDAL());
        // GET: AdminCategory
        public ActionResult Index()
        {
            
            var liste = _categoryManager.GetList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category parameter)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(parameter);
            if (results.IsValid)
            {
                _categoryManager.Add(parameter);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(parameter);
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = _categoryManager.GetByID(id);
            _categoryManager.Delete(categoryvalue);
            return View("Index");
        }
        public ActionResult EditCategory(int id)
        {
            return View(_categoryManager.GetByID(id));
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            _categoryManager.Update(category);
            return RedirectToAction("Index");
        }
    }
}