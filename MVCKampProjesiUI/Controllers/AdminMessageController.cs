using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKampProjesiUI.Controllers
{
    public class AdminMessageController : Controller
    {
        MessageManager messageManager  = new MessageManager(new EfMessageDal());
        //MessageValidator validationRules = new MessageValidator();
        public ActionResult Inbox()
        {
            var messageValue = messageManager.GetListInbox();
            return View(messageValue);
        }
        public ActionResult Sendbox()
        {
            var messageValue = messageManager.GetListSendbox();
            return View(messageValue);
        }

        public ActionResult InboxMessageDetails(int id)
        {
            var messageValue = messageManager.GetById(id);
            return View(messageValue);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            return View();
        }
    }
}