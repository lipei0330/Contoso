using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Services;
using Contoso.Entities;

namespace Contoso.Web.Controllers
{
    [RoutePrefix("student")]
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: Student
        [Route("index")]
        public ActionResult GetStudents()
        {
            var students = _studentService.GetStudents();
            return View(students);
        }

        public ActionResult Details(int Id)
        {
            var student = _studentService.GetStudentById(Id);
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(student);
               
                return RedirectToAction("GetStudents");
            }

            return View();
        }

        //GET: Student/Edit/5
        public ActionResult Edit(int Id)
        {
            // display the info of student by Id
            Student student = _studentService.GetStudentById(Id);
            if(student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Edit(student);
                
                return RedirectToAction("GetStudents");
            }

            return View(student);
        }

        //GET: Student/Delete/5
        public ActionResult Delete(int Id)
        {
            Student student = _studentService.GetStudentById(Id);
            if(student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _studentService.Delete(id);
               
        //        return RedirectToAction("GetStudents");
        //    }
        //    return View();
        //}




    }
}