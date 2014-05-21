using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Orgchart.Web.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentId { get; set; }

        public int manager_id { get; set; }
        public string name { get; set; }
        public int parent_department_id { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }


    }
}