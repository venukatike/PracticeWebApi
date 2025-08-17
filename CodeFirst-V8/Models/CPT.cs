using System.ComponentModel.DataAnnotations;

namespace CodeFirst_V8.Models
{
    public class CPT
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
