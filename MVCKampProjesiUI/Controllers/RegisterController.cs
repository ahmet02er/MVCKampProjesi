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
    }
}