using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Orgchart.Web.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string skype_name { get; set; }
        public int job_title_id { get; set; }
        public bool is_manager { get; set; }
        public int manager_id { get; set; }
        public int department_id { get; set; }
    }
}