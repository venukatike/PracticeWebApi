using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticeWebApi.Model
{
    public class Departments
    {
            [Key]
            public int DepartmentId { get; set; }

            public string Name { get; set; }
        
    }
}
