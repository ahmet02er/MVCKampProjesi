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
    [Authorize(Roles = "Admin")]
    public class AdminAboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValue = aboutManager.GetList();
            return View(aboutValue);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AddAboutPartial()
        {
            return PartialView();
        }

        public ActionResult DeleteAbout(int id)
        {
            var aboutValue = aboutManager.GetById(id);
            if (aboutValue.AboutStatus == true)
            {
                aboutValue.AboutStatus = false;
            }
            else
            {
                aboutValue.AboutStatus = true;
            }

            aboutManager.AboutDelete(aboutValue);
            return RedirectToAction("Index");
        }
    }
}