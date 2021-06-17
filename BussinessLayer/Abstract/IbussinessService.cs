using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IBussinessService<T>
    {
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> filter);
        List<T> GetListActives();
        void Add(T parameter);
        T GetByID(int id);
        void Delete(T parameter);
        void Update(T parameter);
        int Count();
        int Count(Expression<Func<T, bool>> filter);
        int GetIDByName(string Name);
        int MaxID(Expression<Func<T, int>> filter);
    }
}
