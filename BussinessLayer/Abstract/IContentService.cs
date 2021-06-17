using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    interface IContentService:IBussinessService<Content>
    {
        List<Content> GetContentsByHeadingID(int hid);
        List<Content> GetContentsByWriterID(int wid);

    }
}
