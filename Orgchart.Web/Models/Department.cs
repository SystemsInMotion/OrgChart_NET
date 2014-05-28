using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orgchart.Web.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Column("Department_Id")]
        public int DepartmentId { get; set; }

        [Column("manager_id")]
        public int? ManagerId { get; set; }
        
        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("parent_department_id")]
        public int? ParentDepartmentId { get; set; }


        public virtual Department ParentDepartment { get; set; }



        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Department> ChildDepartments { get; set; }
    }
}