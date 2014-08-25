using System.Data.Entity;
using Orgchart.Web.Models;

namespace Orgchart.Web.Infrastructure
{
    public class OrgchartDbContext
        : DbContext
    {
        public OrgchartDbContext()
            : base("orgchartConnectionString")
        {
        }

        public DbSet<JobTitle> JobTitles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTitle>().HasKey(_ => _.Id).ToTable("Job_Title");
            modelBuilder.Entity<JobTitle>().Property(_ => _.Id).HasColumnName("JOB_TITLE_ID");
            modelBuilder.Entity<JobTitle>().Property(_ => _.Description).HasColumnName("DESCRIPTION");
        }
    }
}