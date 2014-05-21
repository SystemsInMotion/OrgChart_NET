using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Orgchart.Web.Tests
{
    [TestClass]
    public class DbContext_specs
    {
        [TestMethod]
        public void Can_connect_to_database()
        {
            var cs = ConfigurationManager.ConnectionStrings["DatabaseContext"];
            var conn = new SqlConnection("");
        }
    }
}