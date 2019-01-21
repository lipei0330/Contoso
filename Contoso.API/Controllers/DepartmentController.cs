using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contoso.Entities;
using Contoso.Services;

namespace Contoso.API.Controllers
{
    [RoutePrefix("api/departments")]
    public class DepartmentController : ApiController
    {
        //private DepartmentService departmentService;
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
           
        }


        //public IEnumerable<Department> GetAllDepts()
        //{
        //    return departmentService.GetAllDepartments();

        //}
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllDepts()
        {
            // var response = Request.CreateResponse();
            var departments = _departmentService.GetAllDepartments();
            if (departments.Count() > 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, departments);
                return ResponseMessage(response);
               // return Ok(departments);

            }
            var noResponse = Request.CreateResponse(HttpStatusCode.NotFound, "No dept found!");

            // return NotFound();
            return ResponseMessage(noResponse);
        }

        [HttpGet]
        [Route("someDepts")]
        public HttpResponseMessage GetSomeDept()
        {
            var departments = _departmentService.GetAllDepartments().Where(d => d.Id > 10);
            if (departments.Count() > 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, departments);
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "No Department Found!");
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetDeptById(int id)
        {
            var dept = _departmentService.GetDepartmentById(id);
            if (dept != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dept);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No dept");
        }

       

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateDept(Department department)
        {
            if (string.IsNullOrEmpty(department.Name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Dept name can not be empty!");
            }

            try
            {
                _departmentService.AddDepartment(department);
                
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "plese try again later");
            }
        }

        [HttpPost]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateDept(Department department)
        {
            if (string.IsNullOrEmpty(department.Name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Dept name can not be empty!");
            }

            try
            {
                _departmentService.Edit(department);
               
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "plese try again later");
            }
        }


    }
}
