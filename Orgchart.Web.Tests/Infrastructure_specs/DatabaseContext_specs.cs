using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orgchart.Web.Infrastructure;
using Orgchart.Web.Models;

namespace Orgchart.Web.Tests.Infrastructure_specs
{
    public class JobTitle_specs
    {
        public class Create_specs
        {

        }

        public class Update_specs
        {

        }
    }

    [TestClass]
    public class DatabaseContext_specs
    {
        

        [TestMethod]
        public void Can_update_JobTitle()
        {
            CreateJobTitle();

            _jobTitle.Description = "test2";

            _context.SaveChanges();

            var db2 = new DatabaseContext();
            var jt2 = db2.JobTitles.SingleOrDefault(_ => _.Description == "test2");

            if (jt2 == null)
                Assert.Fail();

            Assert.IsTrue(_jobTitle.Id == jt2.Id);
        }

        private DatabaseContext _context;
        private JobTitle _jobTitle;
        
        [TestMethod]
        public void Can_create_JobTitle()
        {
            CreateJobTitle();

            var db2 = new DatabaseContext();
            var jt2 = db2.JobTitles.SingleOrDefault(_ => _.Description == "test");

            if (jt2 == null)
                Assert.Fail();

            Assert.IsTrue(_jobTitle.Id == jt2.Id);
        }

        private void CreateJobTitle()
        {
            _context = new DatabaseContext();

            _jobTitle = new JobTitle {Description = "test"};

            _context.JobTitles.Add(_jobTitle);

            _context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.JobTitles.Remove(_jobTitle);
            _context.SaveChanges();
        }
    }
}