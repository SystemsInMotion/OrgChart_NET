using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Orgchart.Web.Infrastructure;
using Orgchart.Web.Models;

namespace Orgchart.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Departments
        public ActionResult Index()
        {

            try
            {
                return View(db.Departments.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return HttpNotFound();
            
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            
            //get parent dept name
            var item = db.Departments.Find(id);
            if (item.ParentDepartmentId != null)
            {
                ViewBag.parent_name = db.Departments.Find(item.ParentDepartmentId).Name;
            }
            else
            {
                ViewBag.parent_name = "n/a";
            }

            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            var items = db.Departments
             .ToList()
             .Select(c => new SelectListItem
             {
                 Value = c.DepartmentId.ToString(CultureInfo.InvariantCulture),
                 Text = c.Name
             });
            var selectListItems = items as IList<SelectListItem> ?? items.ToList();
            var itemsComplete = selectListItems.ToList();
            itemsComplete.Insert(0, new SelectListItem { Value = null, Text = "n/a" });
            ViewBag.Departments = itemsComplete;
            

            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,manager_id,name,parent_department_id")] Department department, string departments)
        {
            //var deptList = Helper.GetDropDownList<Department>("Name", "Department name", "N/A");
            //ViewBag.Departments = deptList;
            
           

            if (ModelState.IsValid)
            {
                if (departments != null && departments != "n/a")
                {
                    department.ParentDepartmentId = Convert.ToInt16(departments);
                    department.ParentDepartment = db.Departments.Find(department.ParentDepartmentId);
                    db.Departments.Find(department.ParentDepartmentId).ChildDepartments.Add(department);
                }
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);

            var items = db.Departments
                .ToList()
                .Where(c => c.DepartmentId != department.DepartmentId)
                //.Select(c => c);
            .Select(c => new SelectListItem
            {
                Value = c.DepartmentId.ToString(CultureInfo.InvariantCulture),
                Text = c.Name,
                Selected = (c.DepartmentId== department.ParentDepartmentId)
            });
            var selectListItems = items as IList<SelectListItem> ?? items.ToList();
            var itemsComplete = selectListItems.ToList();

            //var stuff = new List<SelectListItem>();

            //foreach (var item in items)
            //{
            //    var item_to_add = new SelectListItem();
            //    if (item.DepartmentId == department.ParentDepartmentId)
            //        item_to_add = new SelectListItem()
            //        {
            //            Text = item.Name,
            //            Value = item.DepartmentId.ToString(CultureInfo.InvariantCulture),
            //            Selected = true
            //        };
            //    else
            //    {
            //        item_to_add = new SelectListItem()
            //        {
            //            Text = item.Name,
            //            Value = item.DepartmentId.ToString(CultureInfo.InvariantCulture),
            //            Selected = false
            //        };
            //    }
            //    stuff.Add(item_to_add);
            //}

            //SelectList listComplete = new SelectList(items, new SelectListItem { Value = department.ParentDepartmentId.ToString(), Text = department.ParentDepartment.Name }.Value);
            //SelectList listComplete = new SelectList(items);//, new SelectListItem { Value = department.ParentDepartmentId.ToString(), Text = department.ParentDepartment.Name }.Value);
            itemsComplete.Insert(0, new SelectListItem { Value = null, Text = "n/a" });
            
            ViewBag.DepartmentsList = itemsComplete;
            
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,manager_id,name,parent_department_id")] Department department, string departments)
        {
            if (ModelState.IsValid)
            {
                if (departments!=null && departments!="n/a")
                    department.ParentDepartmentId = Convert.ToInt16(departments);
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
          

              ViewBag.IsParent = department.ChildDepartments.Count() != 0;
                
            
            
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            
            if (department.ChildDepartments.Count()!=0)
            {

                foreach (var child in department.ChildDepartments)
                {
                    child.ParentDepartmentId = null;
                    //db.Departments.Find(childId).ParentDepartmentId = null;
                }
            }


            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
