using Contoso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contoso.Web.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        // GET: Enrollment
        public ActionResult GetEnrollments()
        {
            var enrollments = _enrollmentService.GetEnrollments();
            return View(enrollments);
        }

        public ActionResult Details(int Id)
        {
            var enrollment = _enrollmentService.GetEnrollmentById(Id);
            return View(enrollment);
        }
    }
}