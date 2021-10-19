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
    public class AdminHeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValue = headingManager.GetList();
            return View(headingValue);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.categoryValue = categoryValue;
            List<SelectListItem> writerValue = (from x in writerManager.GetList()
                                                select new SelectListItem
                                                { Text = x.WriterLastName + " " + x.WriterSurName, Value = x.WriterId.ToString() }).ToList();
            ViewBag.writerValue = writerValue;
            return View();
        }


        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
            /*
            HeadingValidator headingValidator = new HeadingValidator();
            ValidationResult validationResult = headingValidator.Validate(heading);
            if (validationResult.IsValid)
            {
                headingManager.HeadingAdd(heading);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            */
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.categoryValue = categoryValue;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }

            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}