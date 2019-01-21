using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Entities;

namespace Contoso.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ContosoDbContext contosoDbContext) : base(contosoDbContext)
        {
        }
    }

    public interface IStudentRepository : IRepository<Student>
    {

    }
}
