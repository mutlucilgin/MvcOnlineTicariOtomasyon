using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        Context c = new Context();
        // GET: ProductDetail
        public ActionResult Index()
        {
            ProductMergeClass mergeTables = new ProductMergeClass();
            mergeTables.ProductList = c.Products.Where(x => x.ProductId == 1).ToList();

            // İlerleyen zamanlar burası düzeltilmeli. Şuan manuel olarak detay çağırılıyor.
            mergeTables.ProductDetailList = c.ProductDetails.Where(y => y.DetailId == 1).ToList(); 
            return View(mergeTables);
        }
    }
}