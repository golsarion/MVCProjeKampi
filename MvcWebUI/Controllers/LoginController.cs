using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcWebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDAL());
        WriterManager _wm = new WriterManager(new EfWriterDAL());
        // GET: Login
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string AdminUserName,string AdminPassword)
        {          
            var adminuserinfo =adm.Login(AdminUserName,AdminPassword);
            if (adminuserinfo != null)
            {
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else return RedirectToAction("SignIn");
        }
        public ActionResult SignOut()
        {
            adm.LogOut(User.Identity.Name);
            return View("SignIn");
        }
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(string WriterMail, string WriterPassword,string ReturnUrl)
        {
            
            var writeruserinfo = _wm.Login(WriterMail, WriterPassword);
            if (writeruserinfo != null)
            {
                Session["WriterMail"] = writeruserinfo.WriterMail;
                Session["WriterID"] = writeruserinfo.WriterID;
                if (!string.IsNullOrEmpty(ReturnUrl))
                {

                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("WriterProfile", "WriterPanel");
            }
            else return RedirectToAction("WriterLogin");
        }
        public ActionResult WriterSignOut()
        {
            _wm.LogOut(User.Identity.Name);
            return View("WriterLogin");
        }
    }
}