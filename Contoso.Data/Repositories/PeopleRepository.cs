using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Entities;

namespace Contoso.Data.Repositories
{
    public class PeopleRepository : BaseRepository<People>, IPeopleRepository
    {
        public PeopleRepository(ContosoDbContext contosoDbContext) : base(contosoDbContext)
        {

        }
    }

    public interface IPeopleRepository : IRepository <People>
    {

    }
}
