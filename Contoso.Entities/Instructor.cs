using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Entities
{
   public class Instructor
    {
        
        [ForeignKey("People")]
        public int Id { get; set; }
        public DateTime HireDate { get; set; }

        // navigation properties

        public People People { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Course> Courses { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }

    }
}
