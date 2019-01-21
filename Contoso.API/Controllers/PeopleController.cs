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
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        //private PeopleService peopleService;

        //public PeopleController()
        //{
        //    peopleService = new PeopleService();
        //}

        //[HttpGet]
        //[Route("")]
        //public IHttpActionResult GetPeoples()
        //{
        //    var pplLst = peopleService.GetAllPeople();
        //    if (pplLst.Count() > 0)
        //    {
        //        var response = Request.CreateResponse(HttpStatusCode.OK, pplLst);
        //        return ResponseMessage(response);
        //    }
        //    var noResponse = Request.CreateResponse(HttpStatusCode.NotFound, "No people Found!");
        //    return ResponseMessage(noResponse);
        //}

        //[HttpGet]
        //[Route("GetMany")]
        //public HttpResponseMessage GetSomePpl()
        //{
        //    var ppl = peopleService.GetAllPeople().Where(p => p.Id > 20);
        //    if (ppl.Count() > 0)
        //    {
        //        var response = Request.CreateResponse(HttpStatusCode.OK, ppl);
        //        return response;
        //    }
        //    return Request.CreateResponse(HttpStatusCode.NotFound, "No people found!");
        //}

        //[HttpGet]
        //[Route("{id:int}")]
        //public HttpResponseMessage GetPplById(int id)
        //{
        //    var ppl = peopleService.GetPeopleById(id);
        //    if (ppl != null)
        //    {
        //        var response = Request.CreateResponse(HttpStatusCode.OK, ppl);
        //        return response;
        //    }
        //    return Request.CreateResponse(HttpStatusCode.NotFound, "No people found");
        //}

        //[HttpPost]
        //[Route("")]
        //public HttpResponseMessage CreatePpl(People people)
        //{
        //    if (string.IsNullOrEmpty(people.LastName))
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "Last name can not be null!");
        //    }

        //    try
        //    {
        //        peopleService.AddPeople(people);
        //        return Request.CreateResponse(HttpStatusCode.Created);

        //    }
        //    catch (Exception)
        //    {

        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please try again!");
        //    }
        //}

        //[HttpPost]
        //[Route("{id:int}")]
        //public HttpResponseMessage DeletePpl(People people)
        //{
        //    if (string.IsNullOrEmpty(people.LastName))
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "You did not select any people to delete!");
        //    }

        //    try
        //    {
        //        peopleService.DeletePeople(people);
        //        return Request.CreateResponse(HttpStatusCode.OK, "People deleted!");

        //    }
        //    catch (Exception)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, "please try again!");

        //    }


        //}

        private readonly IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetPeoples()
        {
            var pplLst = _peopleService.GetAllPeople();
            if (pplLst.Count() > 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, pplLst);
                return ResponseMessage(response);
            }
            var noResponse = Request.CreateResponse(HttpStatusCode.NotFound, "No people Found!");
            return ResponseMessage(noResponse);
        }

        [HttpGet]
        [Route("GetMany")]
        public HttpResponseMessage GetSomePpl()
        {
            var ppl = _peopleService.GetAllPeople().Where(p => p.Id > 20);
            if (ppl.Count() > 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, ppl);
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No people found!");
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetPplById(int id)
        {
            var ppl = _peopleService.GetPeopleById(id);
            if (ppl != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, ppl);
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No people found");
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreatePpl(People people)
        {
            if (string.IsNullOrEmpty(people.LastName))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Last name can not be null!");
            }

            try
            {
                _peopleService.AddPeople(people);
                return Request.CreateResponse(HttpStatusCode.Created);

            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please try again!");
            }
        }

        [HttpPost]
        [Route("{id:int}")]
        public HttpResponseMessage DeletePpl(int id)
        {
            //if (string.IsNullOrEmpty(Convert.ToString(id)))
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, "You did not select any people to delete!");
            //}

            try
            {
                _peopleService.DeletePeople(id);
                return Request.CreateResponse(HttpStatusCode.OK, "People deleted!");

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "please try again!");

            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdatePpl(People people)
        {
            try
            {
                _peopleService.EditPeople(people);
                return Request.CreateResponse(HttpStatusCode.OK, "People updated!");

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "please try again!");

            }

        }



    }
}
