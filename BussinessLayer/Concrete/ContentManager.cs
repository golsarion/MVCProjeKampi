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
    public class ContentManager : IContentService
    {
        IContentDAL _ContentDAL;

        public ContentManager(IContentDAL ContentDAL)
        {
            _ContentDAL = ContentDAL;
        }

        public void Add(Content parameter)
        {
            _ContentDAL.Insert(parameter);
        }

        public int Count()
        {
            return _ContentDAL.Count();                
        }

        public int Count(Expression<Func<Content, bool>> filter)
        {
           return _ContentDAL.Count(filter);
        }

        public void Delete(Content parameter)
        {
            _ContentDAL.Delete(parameter);
        }

        public Content GetByID(int id)
        {
            return _ContentDAL.Get(x => x.ContentID == id);
        }

        public List<Content> GetContentsByHeadingID(int hid)
        {
            return _ContentDAL.List(x => x.HeadingID == hid);
        }

        public List<Content> GetContentsByWriterID(int wid)
        {
            return _ContentDAL.List(x => x.WriterID == wid);
        }

        public int GetIDByName(string Name)
        {
            return _ContentDAL.Get(x => x.ContentValue==Name).ContentID;
        }
        public List<Content> GetList()
        {
            return _ContentDAL.List();
        }

        public List<Content> GetList(Expression<Func<Content, bool>> filter)
        {
            return _ContentDAL.List(filter);
        }

        public List<Content> GetListActives()
        {
            throw new NotImplementedException();
        }

        public int MaxID(Expression<Func<Content, int>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Content parameter)
        {
            _ContentDAL.Update(parameter);
        }
    }
}
