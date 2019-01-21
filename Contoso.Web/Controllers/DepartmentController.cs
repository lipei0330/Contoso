using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Data;
using Contoso.Entities;
using Contoso.Services;

namespace Contoso.Web.Controllers
{
   // [RoutePrefix("dept")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Department
        //[Route("DEPTS")]
        //[Route("index")]
        public ActionResult GetDepartments()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        //[Route]
        public ActionResult Details(int Id)
        {
            var department = _departmentService.GetDepartmentById(Id);

            return View(department);
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create2(FormCollection collection)
        //{
        //    var departName = collection["name"];
        //    var departBudge =Convert.ToDecimal(collection["budget"]);
        //    var departInstructorId = Convert.ToInt32(collection["InstructorId"]);
        //    Department dept = new Department() { Name = departName, Budget = departBudge, InstructorId = departInstructorId};
        //    departmentService.AddDepartment(dept);
        //    departmentService.SaveChange();
        //    return RedirectToAction("GetDepartments");
        //}


        // it will get the value from the html page, as long as the name is same with the property name in Department(incase sensitive)
        [HttpPost]
        public ActionResult Create(Department department, string name)
        {
            if (ModelState.IsValid)
            {
                _departmentService.AddDepartment(department);
                
                return RedirectToAction("GetDepartments");
            }

            return View();
          
        }

        //add search button to search the department by name
        //[Route("ByName")]
        public ActionResult GetByName(string DeptName)
        {
            var deptName = DeptName;
            var departments = _departmentService.GetAllDepartments();
            if (!String.IsNullOrEmpty(deptName))
            {
                departments = _departmentService.GetDeptByName(deptName);
                return View(departments);
            }
            return View(departments);
            
        }

        public void UpdateDept(Department dept)
        {
            _departmentService.Edit(dept);
        }

        //add the search button to search the department by IntructorId
        //[Route("search")]
        public ActionResult SearchDeptByInstructor(string instName, string deptName)
        {
           // var departmentInstructorId = departmentService.GetAllDepartments().Select(d => d.InstructorId).Distinct().ToList();
            PeopleService peopleService = new PeopleService();
            var InstNameLst = peopleService.GetAllPeople(); 
            ViewBag.instName = new SelectList(InstNameLst, "LastName", "LastName");

            //String parameter = Request.Form["instName"];
            //var Id = InstNameLst.Where(x => x.LastName == parameter).Select(d => d.Id).ToList();
            //ViewBag.deptName = new SelectList(departmentService.GetAllDepartments().Where(x => Id.Contains(x.InstructorId)), "Name", "Name");


            Department dept = new Department();
            var depts = _departmentService.GetAllDepartments();
            ViewBag.deptName = new SelectList(depts, "Name", "Name");
 

            if (!String.IsNullOrEmpty(instName))
            {
                //var Id = InstNameLst.Where(x => x.LastName == Request.Form["instName"]).Select(d => d.Id).ToList();
                var Ids = InstNameLst.Where(x => x.LastName == instName).Select(d => d.Id).ToList();

                ViewBag.deptName = new SelectList(_departmentService.GetAllDepartments().Where(x => Ids.Contains(x.InstructorId)), "Name", "Name");
                depts = _departmentService.GetAllDepartments().Where(x => Ids.Contains(x.InstructorId)).ToList();

                if (!String.IsNullOrEmpty(deptName))
                {
                    //var insId = peopleService.GetAllPeople().Where(p => p.LastName == instName).ToList();

                    //depts = departmentService.GetAllDepartments().Where(d => )

                    depts = depts.Where(x=>x.Name == deptName).ToList();

                }
                
            }

            //return View(depts);
            return RedirectToAction("GetDepartments",depts);
            
            
        }

        


    }
}