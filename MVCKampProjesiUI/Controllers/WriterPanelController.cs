using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules.FluentValidation;
using System.Security.Cryptography;
using System.Text;

namespace MVCKampProjesiUI.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator validationRules = new WriterValidator();
        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile()
        {
           string session = (string)Session["WriterMail"];
           int id = context.Writers.Where(x => x.WriterMail == session).Select(y => y.WriterId).FirstOrDefault();
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {

            ValidationResult validationResult = validationRules.Validate(writer);
            if (validationResult.IsValid)
            {
                SHA256 writerHash = new SHA256CryptoServiceProvider();
                string userName = writer.WriterUserName;
                string password = writer.WriterPassword;
                string userNameResult = Convert.ToBase64String(writerHash.ComputeHash(Encoding.UTF8.GetBytes(userName)));
                string passwordResult = Convert.ToBase64String(writerHash.ComputeHash(Encoding.UTF8.GetBytes(password)));
                writer.WriterUserName = userNameResult;
                writer.WriterPassword = passwordResult;
                writerManager.WriterUpdate(writer);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public ActionResult WriterHeading(string session)
        {

            session = (string)Session["WriterMail"];
            var writeruserinfo = context.Writers.Where(x => x.WriterMail == session).Select(y => y.WriterId).FirstOrDefault();
            var headingValue = headingManager.GetListByWriter(writeruserinfo);
            return View(headingValue);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.categoryValue = categoryValue;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string session = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == session).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("WriterProfile");
        }

        [HttpGet]
        public ActionResult UpdateWriterHeading(int id)
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.categoryValue = categoryValue;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult UpdateWriterHeading(Heading heading)
        {
            heading.HeadingStatus = true;
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("WriterHeading");
        }
        public ActionResult DeleteWriterHeading(int id)
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
            return RedirectToAction("WriterHeading");
        }

        public ActionResult AllHeading(int page=1)
        {
            var headings = headingManager.GetList().ToPagedList(page, 5);
            return View(headings);
        }


    }
}