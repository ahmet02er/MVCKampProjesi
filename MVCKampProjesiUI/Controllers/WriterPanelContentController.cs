using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKampProjesiUI.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        public ActionResult WriterContent(string writer, string writerMail)
        {
            writer = (string)Session["Writer"];
            writerMail= (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterId).FirstOrDefault();
            var contentValue = contentManager.GetListByWriter(writerId);
            ViewBag.writer = writer;
            return View(contentValue);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.headingId = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string writerMail = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerId;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("WriterContent");
        }
    }
}