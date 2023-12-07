using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        Context c = new Context();
        // GET: Customer
        public ActionResult Index()
        {
            var values = c.Customers.Where(x=>x.State==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CustomerAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerAdd(Customer newCustomer)
        {
            newCustomer.State = true;
            c.Customers.Add(newCustomer);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var customer = c.Customers.Find(id);
            customer.State = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerUpdate(int id)
        {
            var customer = c.Customers.Find(id);
            return View("CustomerUpdate", customer);
        }
        public ActionResult Update(Customer cust)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerUpdate");
            }
            var customer = c.Customers.Find(cust.CustomerID);
            customer.CustomerName= cust.CustomerName;
            customer.CustomerSurname= cust.CustomerSurname;
            customer.CustomerMail= cust.CustomerMail;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSale(int id)
        {
            var values = c.SalesTransactions.Where(x => x.CustomerId == id).ToList();
            var customerName = c.Customers.Where(x => x.CustomerID == id).Select(y => y.CustomerName).FirstOrDefault();
            ViewBag.CustomerName = customerName;
            return View(values);
        }
    }
}