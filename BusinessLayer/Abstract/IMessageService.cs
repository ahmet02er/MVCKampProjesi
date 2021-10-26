using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {
        //List<Message> GetListInbox(string listInbox);
        //List<Message> GetListSendbox(string listSendbox);
        List<Message> GetListInbox(string parametre);
        List<Message> GetListSendbox(string parametre);
        List<Message> GetAllList();
        List<Message> GetListUnRead();
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
