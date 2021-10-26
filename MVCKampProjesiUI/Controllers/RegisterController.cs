using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCKampProjesiUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            SHA256 adminHash = new SHA256CryptoServiceProvider();
            string userName = admin.AdminUsername;
            string password = admin.AdminPassword;
            string userNameResult = Convert.ToBase64String(adminHash.ComputeHash(Encoding.UTF8.GetBytes(userName)));
            string passwordResult = Convert.ToBase64String(adminHash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminUsername = userNameResult;
            admin.AdminPassword = passwordResult;
            admin.AdminRole = "Admin";
            admin.AdminStatus = true;
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterRegister(Writer writer)
        {
            SHA256 writerHash = new SHA256CryptoServiceProvider();
            string userName = writer.WriterUserName;
            string password = writer.WriterPassword;
            string userNameResult = Convert.ToBase64String(writerHash.ComputeHash(Encoding.UTF8.GetBytes(userName)));
            string passwordResult = Convert.ToBase64String(writerHash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            writer.WriterUserName = userNameResult;
            writer.WriterPassword = passwordResult;
            writer.WriterStatus = true;
            writerManager.WriterAdd(writer);
            return RedirectToAction("writerLogin", "Login");
        }
    }
}