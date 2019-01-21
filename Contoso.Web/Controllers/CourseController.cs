using Contoso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contoso.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseSerive;

        public CourseController(ICourseService courseService)
        {
            _courseSerive = courseService;
        }
        // GET: Course
        public ActionResult GetCourses()
        {
            var courses = _courseSerive.GetCourses();
            return View(courses);
        }

        public ActionResult Details(int Id)
        {
            var course = _courseSerive.GetCourseById(Id);
            return View(course);
        }
    }
}