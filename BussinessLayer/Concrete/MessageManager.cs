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
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL MessageDAL)
        {
            _messageDAL = MessageDAL;
        }

        public void Add(Message parameter)
        {
            _messageDAL.Insert(parameter);
        }

        public int Count()
        {
           return _messageDAL.Count(x=>x.ReceiverMail=="admin@gmail.com");
        }
        public int UnreadCount()
        {
            return _messageDAL.Count(x => x.ReceiverMail == "admin@gmail.com" && x.MessageisRead == false);
        }
        public void Read(Message parameter)
        {
            _messageDAL.Update(parameter);
        }

        public int Count(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message parameter)
        {
            _messageDAL.Delete(parameter);
        }

        public Message GetByID(int id)
        {
            return _messageDAL.Get(x => x.MessageID == id);
        }

        public int GetIDByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetList()
        {
            return _messageDAL.List(x=>x.ReceiverMail=="admin@gmail.com");
        }

        public List<Message> GetList(Expression<Func<Message, bool>> filter)
        {
            return _messageDAL.List(filter);
        }

        public List<Message> GetListActives()
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListInbox()
        {
            return _messageDAL.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetListSendBox()
        {
            return _messageDAL.List(x => x.SenderMail == "admin@gmail.com");
        }

        public int MaxID(Expression<Func<Message, int>> filter)
        {
            throw new NotImplementedException();
        }

        public int ReceiveCount()
        {
            return _messageDAL.Count(x => x.ReceiverMail == "admin@gmail.com");
        }

        public int SendCount()
        {
            return _messageDAL.Count(x => x.SenderMail == "admin@gmail.com");
        }

        public void Update(Message parameter)
        {
            _messageDAL.Update(parameter);
        }
    }
}
