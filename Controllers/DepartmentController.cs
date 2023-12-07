using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();
        // GET: Department
        public ActionResult Index()
        {
            var values = c.Departments.Where(x=> x.State==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department d)
        {
            d.State = true;
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var department = c.Departments.Find(id);
            department.State = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentUpdate(int id)
        {
            var department= c.Departments.Find(id);
            return View("DepartmentUpdate", department);
        }
        public ActionResult Update(Department d)
        {
            var department = c.Departments.Find(d.DepartmentID);
            department.DepartmentName = d.DepartmentName;
            department.State= true;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int id)
        {
            // Birinci Yol
            //var department = c.Departments.Find(id);
            //ViewBag.departmentName = department.DepartmentName;
            //İkinci Yol
            var departmentName = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.departmentName = departmentName;
            var personelList = c.Employees.Where(x => x.DepartmentId == id).ToList();
            
            return View(personelList);
        }
        public ActionResult DepartmentEmployeeSale(int id)
        {
            var values = c.SalesTransactions.Where(x => x.EmployeeId == id).ToList();
            ViewBag.EmployeeName= c.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployeeName+ " "+y.EmployeeSurname).FirstOrDefault();
            return View(values);
        }
    }
}