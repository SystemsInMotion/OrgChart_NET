using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace Orgchart.Web.Models
{
    [Table("Job_Title")]
    public class JobTitle
    {
       [Key]
        [Column("JOB_TITLE_ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}