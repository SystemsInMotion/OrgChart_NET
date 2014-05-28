using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Orgchart.Web.Infrastructure;
using Orgchart.Web.Models;

namespace Orgchart.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }



        private void PopulateDropDowns()
        {
            var depts = db.Departments
     .ToList()
     .Select(c => new SelectListItem
     {
         Value = c.DepartmentId.ToString(CultureInfo.InvariantCulture),
         Text = c.Name
     });
            var selectListItems = depts as IList<SelectListItem> ?? depts.ToList();
            var itemsComplete = selectListItems.ToList();
            itemsComplete.Insert(0, new SelectListItem { Value = null, Text = "n/a" });
            ViewBag.Departments = itemsComplete;


            var managers = db.Employees
            .ToList()
            .Where(c => c.IsManager == true)
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(CultureInfo.InvariantCulture),
                Text = c.LastName
            });
            selectListItems = depts as IList<SelectListItem> ?? managers.ToList();
            itemsComplete = selectListItems.ToList();
            itemsComplete.Insert(0, new SelectListItem { Value = null, Text = "n/a" });
            ViewBag.Managers = itemsComplete;

            var jobTitles = db.JobTitles
            .ToList()
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(CultureInfo.InvariantCulture),
                Text = c.Description
            });
            selectListItems = depts as IList<SelectListItem> ?? jobTitles.ToList();
            itemsComplete = selectListItems.ToList();
            itemsComplete.Insert(0, new SelectListItem { Value = null, Text = "n/a" });
            ViewBag.JobTitles = itemsComplete;

        }

        public ActionResult Create()
        {


            PopulateDropDowns();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,SkypeName,IsManager")] Employee employee, string departments, string managers, string jobtitles)
        {
            
   
                if (departments != null && departments != "n/a")
                {
                    employee.DepartmentId = Convert.ToInt16(departments);
                    employee.Department = db.Departments.Find(employee.DepartmentId);
                    ModelState.Remove("DepartmentId");
                }

                if (managers != null && managers != "n/a")
                {
                    employee.ManagerId = Convert.ToInt16(managers);
                    employee.Manager = db.Employees.Find(employee.ManagerId);
                    ModelState.Remove("ManagerId");
                }

                if (jobtitles != null && jobtitles != "n/a")
                {
                    employee.JobTitleId = Convert.ToInt16(jobtitles);
                    employee.JobTitle = db.JobTitles.Find(employee.JobTitleId);
                    ModelState.Remove("JobTitleId");
                }
                


            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            else
            {
                PopulateDropDowns();
                return View(employee);
            }
            return RedirectToAction("Index");
        }
    }
}