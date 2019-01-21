using Contoso.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ContosoDbContext contosoDbContext) : base(contosoDbContext)
        {
        }
    }

    public interface ICourseRepository: IRepository<Course>
    {

    }
}
