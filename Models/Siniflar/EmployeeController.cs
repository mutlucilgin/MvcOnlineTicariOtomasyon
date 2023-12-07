using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class EmployeeController : Controller
    {
        Context c = new Context();
        // GET: Employee
        public ActionResult Index()
        {
            var values = c.Employees.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> val_1 = (from x in c.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName,
                                              Value = x.DepartmentID.ToString()
                                          }).ToList();
            ViewBag.departmentList = val_1;
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employee newEmployee)
        {
            //newEmployee.State = true;
            
            c.Employees.Add(newEmployee);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult Delete(int id)
        //{
        //    var customer = c.Customers.Find(id);
        //    customer.State = false;
        //    c.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult EmployeeUpdate(int id)
        {
            List<SelectListItem> val_1 = (from x in c.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName,
                                              Value = x.DepartmentID.ToString()
                                          }).ToList();
            ViewBag.departmentList = val_1;


            var employee = c.Employees.Find(id);
            return View("EmployeeUpdate", employee);
        }
        public ActionResult Update(Employee emp)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("CustomerUpdate");
            //}
            var employee= c.Employees.Find(emp.EmployeeID);
            employee.EmployeeName = emp.EmployeeName;
            employee.EmployeeSurname = emp.EmployeeSurname;
            employee.EmployeeImage= emp.EmployeeImage;
            employee.DepartmentId = emp.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult CustomerSales(int id)
        //{
        //    var values = c.SalesTransactions.Where(x => x.CustomerId == id).ToList();
        //    var customerName = c.Customers.Where(x => x.CustomerID == id).Select(y => y.CustomerName).FirstOrDefault();
        //    ViewBag.CustomerName = customerName;
        //    return View(values);
        //}
    }
}