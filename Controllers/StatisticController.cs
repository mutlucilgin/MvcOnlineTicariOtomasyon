using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        Context c = new Context();

        // GET: Statistic
        public ActionResult Index()
        {
            var value1 = c.Customers.Count().ToString();
            ViewBag.d1 = value1;
            var value2 = c.Products.Count().ToString();
            ViewBag.d2 = value2;
            var value3 = c.Employees.Count().ToString();
            ViewBag.d3 = value3;
            var value4 = c.Categories.Count().ToString();
            ViewBag.d4 = value4;
            var value5 = c.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5 = value5;
            var value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = value6;
            var value7 = c.Products.Count(x=>x.Stock <= 50).ToString();
            ViewBag.d7 = value7;
            var value8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;
            var value9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;
            var value10 = c.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = value10;
            var value11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = value11;
            var value12 = c.Products.GroupBy(x => x.Brand).OrderByDescending(x=>x.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.d12 = value12;

            var value13 = c.Products.Where(z=>z.ProductId == c.SalesTransactions.GroupBy(x => x.ProductId)
                .OrderByDescending(x => x.Count()).Select(y => y.Key).FirstOrDefault()).Select(x=>x.ProductName).FirstOrDefault();
            ViewBag.d13 = value13;

            var value14 = c.SalesTransactions.Sum(x => x.TotalPrice).ToString();
            ViewBag.d14 = value14;
            DateTime dt = DateTime.Today;
            var value15 = c.SalesTransactions.Count(x => x.Date >= dt).ToString();
            ViewBag.d15 = value15;
            var value16 = c.SalesTransactions.Where(x => x.Date >= dt).Sum(x=>x.TotalPrice).ToString();
            ViewBag.d16 = value16;

            return View();
        }
    }
}