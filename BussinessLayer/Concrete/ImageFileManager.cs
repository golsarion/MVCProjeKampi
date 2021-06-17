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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDAL _imagefileDAL;

        public ImageFileManager(IImageFileDAL ImagefileDAL)
        {
            _imagefileDAL = ImagefileDAL;
        }

        public void Add(ImageFile parameter)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<ImageFile, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(ImageFile parameter)
        {
            throw new NotImplementedException();
        }

        public ImageFile GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int GetIDByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetList()
        {
            return _imagefileDAL.List();
        }

        public List<ImageFile> GetList(Expression<Func<ImageFile, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetListActives()
        {
            throw new NotImplementedException();
        }

        public int MaxID(Expression<Func<ImageFile, int>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(ImageFile parameter)
        {
            throw new NotImplementedException();
        }
    }
}
