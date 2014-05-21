using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orgchart.Web.Models
{
    [Table("JOB_TITLE")]
    public partial class JobTitle
    {
        [Key]
        [Column("JOB_TITLE_ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}