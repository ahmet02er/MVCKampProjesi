using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKampProjesiUI.Controllers
{
    [AllowAnonymous]
    public class SkillCardController : Controller
    {
        SkillCardManager skillCardManager = new SkillCardManager(new EfSkillCardDal());
        public ActionResult Index()
        {

            var skillValue = skillCardManager.GetList();
            return View(skillValue);
        }
    }
}