﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetAllList()
        {
            return _messageDal.List(x => x.MessageReceiverMail == "admin@admin.com").Where(x => x.MessageRead == true).ToList();
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }
        public List<Message> GetListInbox(string parametre)
        {
            return _messageDal.List(x => x.MessageReceiverMail == parametre);
        }

        public List<Message> GetListSendbox(string parametre)
        {
            return _messageDal.List(x => x.MessageSenderMail == parametre);
        }

        public List<Message> GetListUnRead()
        {
            return _messageDal.List(x => x.MessageReceiverMail == "admin@admin.com").Where(x => x.MessageRead == false).ToList();
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
