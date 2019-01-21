using Contoso.Entities;
using Contoso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contoso.API.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetStudents()
        {
            var students = _studentService.GetStudents();
            if (students.Count() > 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, students);
                return ResponseMessage(response);
            }
            var noResponse = Request.CreateResponse(HttpStatusCode.NotFound, "No student Found!");
            return ResponseMessage(noResponse);
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student.EnrollmentDate != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, student);
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No student by this id was found!");
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateStudent(Student student)
        {
            if (string.IsNullOrEmpty(Convert.ToString(student.Id)))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Student Id cannot be empty!");
            }
            try
            {
                _studentService.AddStudent(student);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please try again!");
            }
        }

        [HttpPost]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            try
            {
                _studentService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted!");

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "please try again!");

            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateStudent(Student student)
        {
            try
            {
                _studentService.Edit(student);
                return Request.CreateResponse(HttpStatusCode.OK, "Student updated!");

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "please try again!");

            }

        }


    }
}
