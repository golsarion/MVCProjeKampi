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
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            _writerDAL = writerDAL;
        }

        public void Add(Writer parameter)
        {
            _writerDAL.Insert(parameter);
        }

        public int Count()
        {
            return _writerDAL.Count();
        }

        public int Count(Expression<Func<Writer, bool>> filter)
        {
            return _writerDAL.Count(filter);
        }

        public void Delete(Writer parameter)
        {
            _writerDAL.Delete(parameter);
        }

        public Writer GetByID(int id)
        {
            return _writerDAL.Get(x => x.WriterID == id);
        }

        public int GetIDByName(string Name)
        {
            return _writerDAL.Get(x => x.WriterName == Name).WriterID;
        }

        public List<Writer> GetList()
        {
            return _writerDAL.List();
        }

        public int MaxID(Expression<Func<Writer, int>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Writer parameter)
        {
            _writerDAL.Update(parameter);
        }
    }
}
