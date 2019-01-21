using Contoso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contoso.Web.Controllers
{
    public class OfficeAssignmentController : Controller
    {
        private readonly IOfficeAssignmentService _officeAssignmentService;
        public OfficeAssignmentController(IOfficeAssignmentService officeAssignmentService)
        {
            _officeAssignmentService = officeAssignmentService;
        }
        // GET: OfficeAssignment
        public ActionResult GetOfficeAssignments()
        {
            var officeAssignments = _officeAssignmentService.GetOfficeAssignments();
            return View(officeAssignments);
        }

        public ActionResult Details(int Id)
        {
            var officeAssignment = _officeAssignmentService.GetOfficeAssignmentById(Id);
            return View(officeAssignment);
        }
    }
}