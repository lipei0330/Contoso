using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Entities;

namespace Contoso.Data.Repositories
{
    public class InstructorRepository : BaseRepository<Instructor>, IInstructorRepository
    {
        
        public InstructorRepository(ContosoDbContext contosoDbContext) : base(contosoDbContext)
        {
        }
    }

    public interface IInstructorRepository: IRepository<Instructor>
    {

    }
}
