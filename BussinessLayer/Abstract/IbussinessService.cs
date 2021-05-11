using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IbussinessService<T>
    {
        List<T> GetList();
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
