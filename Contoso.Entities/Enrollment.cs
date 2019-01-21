using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
