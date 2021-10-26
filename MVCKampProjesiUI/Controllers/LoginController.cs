using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCKampProjesiUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

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

            Context context = new Context();
            var adminuserinfo = context.Admins.FirstOrDefault(x => x.AdminUsername == admin.AdminUsername && x.AdminPassword == admin.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUsername, false);
                Session["AdminUserName"] = adminuserinfo.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");
            }
            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifre Yanlış";
            return View();
        }

        [HttpGet]
        public ActionResult writerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult writerLogin(Writer writer)
        {

            SHA256 writerHash = new SHA256CryptoServiceProvider();
            string userName = writer.WriterUserName;
            string password = writer.WriterPassword;
            string userNameResult = Convert.ToBase64String(writerHash.ComputeHash(Encoding.UTF8.GetBytes(userName)));
            string passwordResult = Convert.ToBase64String(writerHash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            writer.WriterUserName = userNameResult;
            writer.WriterPassword = passwordResult;


            Context context = new Context();
            var writeruserinfo = context.Writers.FirstOrDefault(x => x.WriterUserName == writer.WriterUserName && x.WriterPassword == writer.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                Session["Writer"] = writeruserinfo.WriterLastName + " " + writeruserinfo.WriterSurName;
                return RedirectToAction("WriterProfile", "WriterPanel");
            }
            ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifre Yanlış";
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");

        }

    }
}