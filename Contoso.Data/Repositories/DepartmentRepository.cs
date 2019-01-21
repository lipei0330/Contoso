using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Entities;

namespace Contoso.Data.Repositories
{

    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ContosoDbContext contosoDbContext) : base(contosoDbContext)
        {
        }

        public IEnumerable<Department> GetDeptByName(string name)
        {
            return GetMany(n => n.Name == name);
        }
    }

    public interface IDepartmentRepository: IRepository<Department>
    {
        IEnumerable<Department> GetDeptByName(string name);
        // we can have new methods inside 
    }

}
