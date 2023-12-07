using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        Context c = new Context();
        // GET: Sales
        public ActionResult Index()
        {
            var values = c.SalesTransactions.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SalesAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SalesAdd(SalesTransaction s)
        {
            c.SalesTransactions.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}