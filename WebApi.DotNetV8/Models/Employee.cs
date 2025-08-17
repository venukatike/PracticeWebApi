using System.ComponentModel.DataAnnotations;

namespace WebApi.DotNetV8.Models
{
    public class Employee
    {
        [Key]
        [MaxLength(10)]
        public string EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public decimal Salary { get; set; }

        // Future proofing: add navigation properties if needed
        public virtual ICollection<Project> Projects { get; set; }

    }
}
