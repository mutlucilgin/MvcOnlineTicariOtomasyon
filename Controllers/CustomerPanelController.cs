using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context c = new Context();
        // GET: CustomerPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CustomerMail"];
            var customer = c.Customers.FirstOrDefault(x => x.CustomerMail == mail);
            return View(customer);
        }
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CustomerMail"];
            var id = c.Customers.Where(x => x.CustomerMail == mail).Select(y=>y.CustomerID).FirstOrDefault();
            var value = c.SalesTransactions.Where(x => x.CustomerId == id).ToList();
            return View(value);
        }
    }
}