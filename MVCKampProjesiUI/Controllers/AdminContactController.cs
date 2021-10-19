using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKampProjesiUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();
        public ActionResult Index()
        {
            var contactValue = contactManager.GetList();
            return View(contactValue);
        }
        public ActionResult ContactGetDetails(int id)
        {
            var contactValue = contactManager.GetById(id);
            return View(contactValue);
        }
        public PartialViewResult ContactPartial()
        {
            Context context = new Context();
            var receiverMail = context.Messages.Count(x => x.MessageReceiverMail == "admin@admin.com").ToString();
            ViewBag.receiverMail = receiverMail;

            var senderMail = context.Messages.Count(x => x.MessageSenderMail == "admin@admin.com").ToString();
            ViewBag.senderMail = senderMail;

            var contact = context.Contacts.Count().ToString();
            ViewBag.contact = contact;

            var draft = context.Messages.Count(x => x.MessageDraft == true).ToString();
            ViewBag.draft = draft;

            var readMessage = messageManager.GetAllList().Count();
            ViewBag.readMessage = readMessage;

            var unReadMessage = messageManager.GetListUnRead().Count();
            ViewBag.unReadMessage = unReadMessage;

            return PartialView();
        }
    }
}