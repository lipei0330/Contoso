using Contoso.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ContosoDbContext contosoDbContext) : base(contosoDbContext)
        {
        }
    }

    public interface IEnrollmentRepository: IRepository<Enrollment>
    {

    }
}
