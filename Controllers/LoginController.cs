using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        // Müşteri kaydı
        [HttpGet]
        public PartialViewResult Partial_1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial_1(Customer customer)
        {
            c.Customers.Add(customer);
            c.SaveChanges();
            return PartialView();
        }
        // Müşteri Girişi
        [HttpGet]
        public PartialViewResult Partial_2()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Partial_2(Customer customer)
        {
            var value = c.Customers.FirstOrDefault(x =>
                x.CustomerMail == customer.CustomerMail
                && x.CustomerPassword == customer.CustomerPassword
            );
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.CustomerMail, false);
                Session["CustomerMail"] = value.CustomerMail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        // Admin Girişi
        [HttpGet]
        public PartialViewResult Partial_3()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Partial_3(Admin admin)
        {
            var value = c.Admins.FirstOrDefault(x =>
                x.UserName == admin.UserName
                && x.Password== admin.Password
            );
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["UserName"] = value.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}