using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL AboutDAL)
        {
            _aboutDAL = AboutDAL;
        }

        public void Add(About parameter)
        {
            _aboutDAL.Insert(parameter);
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(About parameter)
        {
            _aboutDAL.Delete(parameter);
        }

        public About GetByID(int id)
        {
            return _aboutDAL.Get(x => x.AboutID == id);
        }

        public int GetIDByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            return _aboutDAL.List();
        }

        public List<About> GetList(Expression<Func<About, bool>> filter)
        {
            return _aboutDAL.List(filter);
        }

        public List<About> GetListActives()
        {
            throw new NotImplementedException();
        }

        public int MaxID(Expression<Func<About, int>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(About parameter)
        {
            _aboutDAL.Update(parameter);
        }
    }
}
