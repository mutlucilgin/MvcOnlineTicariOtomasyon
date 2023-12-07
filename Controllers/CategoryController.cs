using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context context = new Context();
        // Get Category
        public ActionResult Index()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryUpdate(int id)
        {
            var category = context.Categories.Find(id);
            return View("CategoryUpdate", category);
        }
        public ActionResult Update(Category c)
        {
            var category = context.Categories.Find(c.CategoryID);
            category.CategoryName = c.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}