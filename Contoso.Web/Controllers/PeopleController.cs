using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Services;
using Contoso.Entities;
namespace Contoso.Web.Controllers
{
    public class PeopleController : Controller
    {
        private PeopleService peopleService;
        public PeopleController()
        {
            peopleService = new PeopleService();
        }
        // GET: People
        public ActionResult GetPeoples()
        {
            var people = peopleService.GetAllPeople();
            return View(people);
        }

        public ActionResult Details(int Id)
        {
            var people = peopleService.GetPeopleById(Id);
            return View(people);
        }

        

        

      
    }
}