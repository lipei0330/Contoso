using Contoso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contoso.API.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCourses()
        {
            var courses = _courseService.GetCourses();
            if (courses.Count() > 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, courses);
                return ResponseMessage(response);
            }
            var noResponse = Request.CreateResponse(HttpStatusCode.NotFound, "No course found!");
            return ResponseMessage(noResponse);
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course.CreatedDate!= null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, course);
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No course found!");
        }



    }
}
