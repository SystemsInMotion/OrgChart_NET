using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using Orgchart.Web.Models;

namespace Orgchart.Web.Infrastructure
{
    public class DatabaseContext
        : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
                        
        }

        public virtual DbSet<JobTitle> JobTitles { get; set; }
    }
}