using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orgchart.Web.Infrastructure;

namespace Orgchart.Web.Controllers
{
    public class JobTitleController 
        : Controller
    {
        private DatabaseContext _context = new DatabaseContext();

        public ActionResult Index()
        {
            return View(_context.JobTitles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var jt = _context.JobTitles.SingleOrDefault(_ => _.Id == id);

            if (jt == null)
                return HttpNotFound("The object was not found");
            
            return View(jt);
        }

        //[HttpPost]
        //public ActionResult EditPost(int id)
        //{

        //}

        public ActionResult Delete(int id)
        {
            var jt = _context.JobTitles.SingleOrDefault(_ => _.Id == id);
            _context.JobTitles.Remove(jt);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}