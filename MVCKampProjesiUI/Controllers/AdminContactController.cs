using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKampProjesiUI.Controllers
{
    public class AdminContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
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
            return PartialView();
        }
    }
}