using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace BussinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDAL _adminDAL;

        public AdminManager(IAdminDAL AdminDAL)
        {
            _adminDAL = AdminDAL;
        }

        public void Add(Admin parameter)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(Admin parameter)
        {
            throw new NotImplementedException();
        }

        public Admin GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int GetIDByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetListActives()
        {
            throw new NotImplementedException();
        }

        public string[] GetRoles(string UserName)
        {
            return new string[] { _adminDAL.Get(x => x.AdminUserName == UserName).AdminRole };
        }

        public Admin Login(string username, string password)
        {
            var hashedpassword = EasyEncryption.MD5.ComputeMD5Hash(password);
            var adminuserinfo= _adminDAL.Get(x => x.AdminUserName == username && x.AdminPassword == hashedpassword);
            FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
            return adminuserinfo;
        }

        public void LogOut(string username)
        {
            FormsAuthentication.SignOut();
        }

        public int MaxID(Expression<Func<Admin, int>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin parameter)
        {
            throw new NotImplementedException();
        }
    }
}
