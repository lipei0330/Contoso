using Contoso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contoso.Web.Controllers
{
    public class RoleController : Controller
    {
        private RoleService roleService;
        public RoleController()
        {
            roleService = new RoleService();
        }
        // GET: Role
        public ActionResult GetRoles()
        {
            var roles = roleService.GetRoles();
            return View(roles);
        }

        public ActionResult Details(int Id)
        {
            var role = roleService.GetRoleById(Id);
            return View(role);
        }
    }
}