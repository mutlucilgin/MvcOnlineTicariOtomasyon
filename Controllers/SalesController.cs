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
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName+" "+x.CustomerSurname,
                                               Value = x.CustomerID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName+" "+x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.products = value1;
            ViewBag.customers = value2;
            ViewBag.employees = value3;
            return View();
        }
        [HttpPost]
        public ActionResult SalesAdd(SalesTransaction s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesTransactions.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesUpdate(int id)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.products = value1;
            ViewBag.customers = value2;
            ViewBag.employees = value3;

            var value = c.SalesTransactions.Find(id);
            return View("SalesUpdate", value);
        }
        [HttpPost]
        public ActionResult Update(SalesTransaction st)
        {
            var value = c.SalesTransactions.Find(st.SalesID);
            value.CustomerId = st.CustomerId;
            value.Number = st.Number;
            value.Price = st.Price;
            value.EmployeeId = st.EmployeeId;
            value.Date = st.Date;
            value.TotalPrice = st.TotalPrice;
            value.ProductId = st.ProductId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int id)
        {
            var values = c.SalesTransactions.Where(x => x.EmployeeId == id).ToList();
            return View(values);
        }
    }
}