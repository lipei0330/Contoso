using Contoso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contoso.API.Controllers
{
    [RoutePrefix("api/instructors")]
    public class InstructorController : ApiController
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetInstructors()
        {
            var instructors = _instructorService.GetInstructors();
            if (instructors.Count() > 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, instructors);
                return ResponseMessage(response);
            }
            var noResponse = Request.CreateResponse(HttpStatusCode.NotFound, "No instructor found!");
            return ResponseMessage(noResponse);
        }
    }
}
