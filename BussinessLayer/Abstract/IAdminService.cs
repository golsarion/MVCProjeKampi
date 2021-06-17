using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IAdminService:IBussinessService<Admin>
    {
        Admin Login(string username, string password);
        string[] GetRoles(string UserName);
        void LogOut(string username);
    }
}
