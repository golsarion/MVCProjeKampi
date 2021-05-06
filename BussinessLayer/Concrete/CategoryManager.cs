using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Category> GetList()
        {
            return _categorydal.List();
        }
    }
}
