using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IbussinessService<T>
    {
        List<T> GetList();
        void Add(T parameter);
    }
}
