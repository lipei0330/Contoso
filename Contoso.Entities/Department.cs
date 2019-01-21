using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Entities
{
   public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public string RowVersion { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }


        //navigation properties
        public Instructor Instructor { get; set; }
        [Required]
        public int InstructorId { get; set; }
        // public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Course> Courses { get; set; }

        
    }
}
