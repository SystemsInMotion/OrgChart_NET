using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Orgchart.Web.Models
{
    [Table("Employee")]
    public class Employee
    {

        [Key]
        [Column("Employee_ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(45)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(45)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(45)]
        [Column("skype_name")]
        public string SkypeName { get; set; }

        [Required]
        [Column("job_title_id")]
        public int JobTitleId { get; set; }

        [Required]
        [Column("is_manager")]
        public bool IsManager { get; set; }

        [Column("manager_id")]
        public int ManagerId { get; set; }

        [Column("department_id")]
        public int DepartmentId { get; set; }
    }
}