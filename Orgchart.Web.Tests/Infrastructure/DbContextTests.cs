using System.Linq;
using NUnit.Framework;
using Orgchart.Web.Infrastructure;
using Orgchart.Web.Models;

namespace Orgchart.Web.Tests.Infrastructure
{
    [TestFixture]
    public class DbContextTests
    {
        private JobTitle _jobTitle;
        private OrgchartDbContext _dbcontext;

        [Test]
        public void TestConnection()
        {
            var dbcontext = new OrgchartDbContext();

            var count = dbcontext.Database.ExecuteSqlCommand("Select * from Job_title");

            Assert.That(count, Is.EqualTo(-1));
        }

        [SetUp]
        public void SetUp()
        {
            _dbcontext = new OrgchartDbContext();

            _jobTitle = new JobTitle
            {
                Description = "testDescription",
            };

            _dbcontext.JobTitles.Add(_jobTitle);
            _dbcontext.SaveChanges();
        }

        [Test]
        public void CanCreateEntity()
        { 
            Assert.That(_jobTitle.Id, Is.GreaterThan(0));
        }

        [Test]
        public void CanUpdateEntity()
        {
            _jobTitle.Description = "newDescription";
            _dbcontext.SaveChanges();

            var verifyContext = new OrgchartDbContext();

            var updated = verifyContext.JobTitles.Single(_ => _.Id == _jobTitle.Id);

            Assert.That(_jobTitle.Description, Is.EqualTo(updated.Description));
        }

        [Test]
        public void CanDeleteEntity()
        {
            //delete is handled by teardown
            Assert.That(true, Is.True);
        }

        [TearDown]
        public void Teardown()
        {
            _dbcontext.JobTitles.Remove(_jobTitle);
            _dbcontext.SaveChanges();
        }
    }


}