using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Orgchart.Web.Models
{
    public class JobTitle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobTitleId { get; set; }

        public string descriprtion { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}