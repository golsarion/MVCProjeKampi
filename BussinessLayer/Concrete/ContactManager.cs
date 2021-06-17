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
    public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;

        public ContactManager(IContactDAL ContactDAL)
        {
            _contactDAL = ContactDAL;
        }

        public void Add(Contact parameter)
        {
            _contactDAL.Insert(parameter);
        }

        public int Count()
        {
            return _contactDAL.Count();
        }

        public int Count(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contact parameter)
        {
            _contactDAL.Delete(parameter);
        }

        public Contact GetByID(int id)
        {
            return _contactDAL.Get(x => x.ContactID == id);
        }

        public int GetIDByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetList()
        {
            return _contactDAL.List();
        }

        public List<Contact> GetList(Expression<Func<Contact, bool>> filter)
        {
            return _contactDAL.List(filter);
        }

        public List<Contact> GetListActives()
        {
            throw new NotImplementedException();
        }

        public int MaxID(Expression<Func<Contact, int>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact parameter)
        {
            _contactDAL.Update(parameter);
        }
    }
}
