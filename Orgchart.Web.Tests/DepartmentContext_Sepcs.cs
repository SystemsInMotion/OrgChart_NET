using System.Linq;
using System.Web.Mvc.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orgchart.Web.Infrastructure;
using Orgchart.Web.Models;

namespace Orgchart.Web.Tests
{
    [TestClass]
    public class DepartmentContext_Sepcs
    {
        private DatabaseContext db = new DatabaseContext();
        private Department d = new Department() { Name = "Python" };
        private Department d2 = new Department();
       private DatabaseContext db2 = new DatabaseContext();


        [TestMethod]
        public void Can_create_Department()
        {
            db.Departments.Add(d);
            db.SaveChanges();

            
            d2 = db2.Departments.SingleOrDefault(_ => _.Name == "Python");

            if (d2 == null)
                Assert.Fail();

            Assert.IsTrue(d.DepartmentId == d2.DepartmentId);

        }


        [TestMethod]
        public void Edit_Department()
        {

            Can_create_Department();

            d = db.Departments.SingleOrDefault(_ => _.Name == "Python");

            if (d != null)
                db.Departments.Find(d.DepartmentId).Name = "bb";
            db.SaveChanges();

            
            db2 = new DatabaseContext();
            d2 = db2.Departments.SingleOrDefault(_ => _.Name == "bb");

            if (d2 == null)
                Assert.Fail();

            Assert.IsTrue(d.DepartmentId == d2.DepartmentId);
            Cleanup();
        }


        [TestMethod]
        public void Delete_department_that_has_children()
        {

            d = new Department() { Name = "bb" };

            db.Departments.Add(d);
            db.SaveChanges();

            d2 = new Department() { Name = "Python" };

            d2.ParentDepartmentId = d.DepartmentId;

            db.Departments.Add(d2);
            db.SaveChanges();

            var d3 = new Department();
            d3 = db.Departments.SingleOrDefault(_ => _.Name == "Python");
            
            if (d3!=null && d3.ParentDepartmentId !=d.DepartmentId)
                Assert.Fail();

            d3.ParentDepartmentId = null;
            db.SaveChanges();


            db.Departments.Remove(d);

            d2 = db.Departments.SingleOrDefault(_ => _.Name == "Python");
            
            if(d2 != null && d2.ParentDepartmentId!=null)
                Assert.Fail();

        }

        [TestCleanup]
        public void Cleanup()
        {
 
            

            d = db.Departments.SingleOrDefault(_ => _.Name == "Python");

            if (d != null)
                db.Departments.Remove(d);
            db.SaveChanges();

            d = db.Departments.SingleOrDefault(_ => _.Name == "bb");

            if (d != null)
                db.Departments.Remove(d);
            db.SaveChanges();
        }
 
    }
}