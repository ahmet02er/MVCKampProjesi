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

    }
}