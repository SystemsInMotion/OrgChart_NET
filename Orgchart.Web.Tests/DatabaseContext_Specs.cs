using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orgchart.Web.Infrastructure;
using Orgchart.Web.Models;

namespace Orgchart.Web.Tests
{
    [TestClass]
    public class DatabaseContext_Specs
    {
        [TestMethod]
        public void Can_create_JobTitle()
        {
            var db = new DatabaseContext();

            var jt = new JobTitle {Description = "test"};

            db.JobTitles.Add(jt);
            db.SaveChanges();

            var db2 = new DatabaseContext();
            var jt2 = db2.JobTitles.SingleOrDefault(_ => _.Description == "test");

            if(jt2 ==null)
                Assert.Fail();

            Assert.IsTrue(jt.Id == jt2.Id);

        }

 
        [TestCleanup]
        public void Cleanup()
        {
            var db = new DatabaseContext();

            var jt = db.JobTitles.SingleOrDefault(_ => _.Description == "test");

            if (jt != null)
                db.JobTitles.Remove(jt);
            db.SaveChanges();

        }
    }
}