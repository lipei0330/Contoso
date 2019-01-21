using Contoso.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoles
    {
        public RoleRepository(ContosoDbContext contosoDbContext) : base(contosoDbContext)
        {
        }
    }

    public interface IRoles: IRepository<Role>
    {


    }
}
