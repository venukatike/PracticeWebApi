using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.DotNetV8.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProjectName { get; set; }

        // ✅ Foreign key
        [Required]
        public string EmployeeId { get; set; }

        // ✅ Navigation back to Employee
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
