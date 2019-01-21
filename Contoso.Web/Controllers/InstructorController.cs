using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Services;

namespace Contoso.Web.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        // GET: Instructor
        public ActionResult GetInstructors()
        {
            var instructors = _instructorService.GetInstructors();
            return View(instructors);
        }
         public ActionResult Details(int Id)
        {
            var instructor = _instructorService.GetInstructorById(Id);
            return View(instructor);
               
        }


    }
}