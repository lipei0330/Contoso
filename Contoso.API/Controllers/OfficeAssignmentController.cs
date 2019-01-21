using Contoso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contoso.API.Controllers
{
    [RoutePrefix("api/officeAssignments")]
    public class OfficeAssignmentController : ApiController
    {
        private readonly IOfficeAssignmentService _officeAssignmentService;

        public OfficeAssignmentController(IOfficeAssignmentService officeAssignmentService)
        {
            _officeAssignmentService = officeAssignmentService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetOfficeAssignments()
        {
            var officeAsmt = _officeAssignmentService.GetOfficeAssignments();
            if (officeAsmt.Count()>0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, officeAsmt);
                return ResponseMessage(response);
            }
            var noResponse = Request.CreateResponse(HttpStatusCode.NotFound, "No office assignment found!");
            return ResponseMessage(noResponse);
        }
    }
}
