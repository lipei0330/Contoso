using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Entities
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Credits { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

        //navigation properties
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }



    }
}
