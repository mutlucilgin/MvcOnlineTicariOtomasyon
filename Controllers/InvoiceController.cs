using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        Context c = new Context();
        // GET: Invoice
        public ActionResult Index()
        {
            var list = c.Invoices.ToList();
            
            return View(list);
        }
        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceAdd(Invoice invoice)
        {
            c.Invoices.Add(invoice);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceUpdate(int id)
        {
            var invoice = c.Invoices.Find(id);
            return View("InvoiceUpdate", invoice);
        }
        public ActionResult Update(Invoice f)
        {
            var invoice = c.Invoices.Find(f.InvoiceID);
            invoice.InvoiceSerialNo = f.InvoiceSerialNo;
            invoice.InvoiceSquenceNo = f.InvoiceSquenceNo;
            invoice.Date = f.Date;
            invoice.Time = f.Time;
            invoice.Reciever = f.Reciever;
            invoice.Deliverir = f.Deliverir;
            invoice.TaxOffice = f.TaxOffice;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult InvoiceDetail(int id)
        {
            //var departmentName = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            //ViewBag.departmentName = departmentName;
            var values = c.InvoiceItems.Where(x => x.InvoiceId == id).ToList();

            return View(values);
        }
        [HttpGet]
        public ActionResult InvoiceItemAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceItemAdd(InvoiceItem invoiceItem)
        {
            c.InvoiceItems.Add(invoiceItem);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}