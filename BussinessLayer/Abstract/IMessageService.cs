using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    interface IMessageService:IBussinessService<Message>
    {
        List<Message> GetListInbox();
        List<Message> GetListSendBox();
        int SendCount();
        int ReceiveCount();
    }
}
