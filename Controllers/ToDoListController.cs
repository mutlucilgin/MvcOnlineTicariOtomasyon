using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        Context c = new Context();
        // GET: ToDoList
        public ActionResult Index()
        {
            var customerCount = c.Customers.Count().ToString();
            var productCount = c.Products.Count().ToString();
            var categoryCount = c.Categories.Count().ToString();
            var customerCityCount = c.Customers.GroupBy(x => x.CustomerCity).Count().ToString();

            ViewBag.customerCount = customerCount;
            ViewBag.productCount = productCount;
            ViewBag.categoryCount = categoryCount;
            ViewBag.customerCityCount = customerCityCount;

            var toDoList = c.ToDoLists.ToList();
            return View(toDoList);
        }
    }
}