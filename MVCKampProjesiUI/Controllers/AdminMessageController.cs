using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKampProjesiUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        MessageManager messageManager  = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();
        public ActionResult Inbox(string session)
        {
            var messageValue = messageManager.GetListInbox(session);
            return View(messageValue);
        }
        public ActionResult Sendbox(string session)
        {
            var messageValue = messageManager.GetListSendbox(session);
            return View(messageValue);
        }

        public ActionResult InboxMessageDetails(int id)
        {
            var messageValue = messageManager.GetById(id);
            return View(messageValue);
        }
        public ActionResult SendboxMessageDetails(int id)
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
        public ActionResult NewMessage(Message message, string button, string session)
        {
            ValidationResult validationResult = validationRules.Validate(message);

            if (button == "draft")
            {
                if (validationResult.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.MessageSenderMail = session;
                    message.MessageDraft = true;
                    messageManager.MessageAdd(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "save")
            {
                if (validationResult.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.MessageSenderMail = session;
                    message.MessageDraft = false;
                    messageManager.MessageAdd(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }
        public ActionResult Draft(string session)
        {
            var sendList = messageManager.GetListSendbox(session);
            var draftList = sendList.FindAll(x => x.MessageDraft == true);
            return View(draftList);
        }

        public ActionResult GetDraftMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }

        public ActionResult IsRead(int id)
        {
            var messageResult = messageManager.GetById(id);
            if (messageResult.MessageRead == false)
            {
                messageResult.MessageRead = true;
            }
            messageManager.MessageUpdate(messageResult);
            return RedirectToAction("ReadMessage");
        }

        public ActionResult ReadMessage()
        {
            var readMessage = messageManager.GetAllList().Where(x => x.MessageRead == true).ToList();
            return View(readMessage);
        }

        public ActionResult UnReadMessage()
        {
            var unReadMessage = messageManager.GetListUnRead();
            return View(unReadMessage);
        }
    }
}