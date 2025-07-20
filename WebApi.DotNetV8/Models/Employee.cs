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

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Department { get; set; }

        [MaxLength(100)]
        public string Designation { get; set; }

        public DateTime DateOfJoining { get; set; }

        public decimal Salary { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string EmployeeCode { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }

        // Future proofing: add navigation properties if needed
         public virtual ICollection<Project> Projects { get; set; }

    }
}
