using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCKampProjesiUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IstatistikController : Controller
    {
        public ActionResult Index()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            Context context = new Context();

            //1) Toplam Kategori Sayısı Ödevi
            var categoryCount = context.Categories.Count();
            ViewBag.categoryCount = categoryCount;



            //2) Yazılım Alanına Ait Başlık Sayısı Ödevi
            var categoryHeading = context.Headings.Count(x => x.CategoryId == 11);
            ViewBag.categoryHeading = categoryHeading;


            //3) Yazar Adında 'a' Harfi Geçen Yazar Sayısı Ödevi
            var writerACharacter = context.Writers.Count(x => x.WriterLastName.Contains("a"));
            ViewBag.writerACharacter = writerACharacter;


            //4) En Çok Başlığa Sahip Kategori Adı Ödevi
            var mostCategory = context.Categories.Where(x => x.CategoryId == context.Headings.GroupBy
            (y => y.CategoryId).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault()).Select
            (x => x.CategoryName).FirstOrDefault();
            ViewBag.mostCategory = mostCategory;


            //5) Kategori Tablosunda Durumu 'true' Olan Kategoriler ile 'false' Olan Kategoriler Arasındaki Sayısal Fark Ödevi

            if (context.Categories.Count(x => x.CategoryStatus == true) > context.Categories.Count(x => x.CategoryStatus == false))
            {
                var categoryDistinctionTrueFalse = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
                ViewBag.categoryDistinctionTrueFalse = categoryDistinctionTrueFalse;
            }
            else
            {
                var categoryDistinctionTrueFalse = context.Categories.Count(x => x.CategoryStatus == false) - context.Categories.Count(x => x.CategoryStatus == true);
                ViewBag.categoryDistinctionTrueFalse = categoryDistinctionTrueFalse;
            }

            return View();
        }
    }
}