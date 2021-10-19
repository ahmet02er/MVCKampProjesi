using BusinessLayer.Abstract;
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
    [AllowAnonymous]
    public class AdminAuthController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        public ActionResult Index()
        {
            var adminValue = adminManager.GetList();
            return View(adminValue);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var adminValue = adminManager.GetByID(id);

            if (adminValue.AdminStatus == true)
            {
                adminValue.AdminStatus = false;
            }
            else
            {
                adminValue.AdminStatus = true;
            }

            adminManager.AdminUpdate(adminValue);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateRole(Admin admin)
        {
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            List<SelectListItem> valueAdminRole = (from role in roleManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = role.RoleName,
                                                       Value = role.RoleId.ToString()

                                                   }).ToList();

            ViewBag.valueAdmin = valueAdminRole;

            var adminvalue = adminManager.GetByID(id);
            return View(adminvalue);
        }
    }
}