using Contoso.Data.Repositories;
using Contoso.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Services
{
    public class RoleService : IRoleService
    {
        private RoleRepository roleRepository;
        public RoleService()
        {
            roleRepository = new RoleRepository(new Data.ContosoDbContext());
        }

        public Role GetRoleById(int Id)
        {
            return roleRepository.GetById(Id);
        }

        public IEnumerable<Role> GetRoles()
        {
            return roleRepository.GetAll();
        }
    }

    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleById(int Id);
    }
}
