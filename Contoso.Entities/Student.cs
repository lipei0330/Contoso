using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Entities
{
    public class Student
    {
        [ForeignKey("People")]
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        //[ForeignKey("Id")]
        public People People { get; set; }
    }
}
