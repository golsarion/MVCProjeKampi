using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categorydal;

        public CategoryManager(ICategoryDAL categorydal)
        {
            _categorydal = categorydal;
        }

        public void Add(Category parameter)
        {
            _categorydal.Insert(parameter);
        }

        public void Delete(Category parameter)
        {
            _categorydal.Delete(parameter);
        }

        public Category GetByID(int id)
        {
            return _categorydal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }

        public int Count()
        {
            return _categorydal.Count();
        }

        public void Update(Category parameter)
        {            
            _categorydal.Update(parameter);
        }

        public int Count(Expression<Func<Category, bool>> filter)
        {
            return _categorydal.Count(filter);
        }

        public int GetIDByName(string Name)
        {
            return _categorydal.Get(x => x.CategoryName == Name).CategoryID;
        }

        public int MaxID(Expression<Func<Category, int>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
