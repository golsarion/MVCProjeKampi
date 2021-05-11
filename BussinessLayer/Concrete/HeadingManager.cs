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
    public class HeadingManager : IHeadingService
    {
        IHeadingDAL _headingDAL;

        public HeadingManager(IHeadingDAL headingDAL)
        {
            _headingDAL = headingDAL;
        }

        public void Add(Heading parameter)
        {
            _headingDAL.Insert(parameter);
        }

        public int Count()
        {
            return _headingDAL.Count();
        }

        public int Count(Expression<Func<Heading, bool>> filter)
        {
            return _headingDAL.Count(filter);
        }

        public void Delete(Heading parameter)
        {
            _headingDAL.Delete(parameter);
        }

        public Heading GetByID(int id)
        {
            return _headingDAL.Get(x => x.HeadingID == id);
        }

        public int GetIDByName(string Name)
        {
            return _headingDAL.Get(x => x.HeadingName == Name).HeadingID;
        }

        public List<Heading> GetList()
        {
            return _headingDAL.List();
        }

        public int MaxID(Expression<Func<Heading, int>> filter)
        {
            return _headingDAL.Max(filter);
        }

        public void Update(Heading parameter)
        {
            _headingDAL.Update(parameter);
        }
    }
}
