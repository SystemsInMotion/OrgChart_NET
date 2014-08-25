using System.Data.Entity;

namespace Orgchart.Web.Infrastructure
{
    public class DbContext2
        : DbContext
    {
        public DbContext2()
            : base("orgchartConnectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}