using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var products = c.Products.Where(x => x.State == true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> val_1 = (from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.value1 = val_1;

            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = c.Products.Find(id);
            product.State = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductUpdate(int id)
        {
            List<SelectListItem> val_1 = (from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.value1 = val_1;

            var product = c.Products.Find(id);
            return View("ProductUpdate", product);
        }
        public ActionResult Update(Product p)
        {
            var product = c.Products.Find(p.ProductId);
            product.ProductName = p.ProductName;
            product.Brand = p.Brand;
            product.Stock = p.Stock;
            product.PurchasePrice = p.PurchasePrice;
            product.SalePrice = p.SalePrice;
            product.Categoryid= p.Categoryid;
            product.ProductImage = p.ProductImage;
            product.State = p.State;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var values = c.Products.ToList();
            return View(values);
        }

    }
}
