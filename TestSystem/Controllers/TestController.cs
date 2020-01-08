using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using TestSystem.Infrastructure;

namespace TestSystem.Controllers
{
    public class TestController : Controller
    {
        private ITestService testService;

        public TestController(ITestService serv)
        {
            testService = serv;
        }

        // GET api/testucts
        [Route("~/api/tests")]
        [HttpGet]
        public IEnumerable<TestDTO> Get()
        {
            try
            {
                return testService.GetTests((test) => true);
            }
            catch (ValidationException ex)
            {
                throw new HttpResponseException { Status = HttpStatusCode.NotFound };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException { Status = HttpStatusCode.InternalServerError};
            }
        }

        // GET api/tests/5
        [Route("~/api/tests/{Id}")]
        [HttpGet]
        public TestDTO Get(int id)
        {
            try
            {
                return testService.GetTest(id);
            }
            catch (ValidationException ex)
            {
                throw new HttpResponseException{ Status = HttpStatusCode.NotFound};
            }
        }

        // POST api/testucts
        [Route("~/api/tests")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]TestDTO testDto)
        {
            try
            {
                testService.AddTest(testDto);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/testucts
        [Route("~/api/tests")]
        [HttpPost]
        public HttpResponseMessage Put([FromBody]TestDTO testuctDto)
        {
            try
            {
                testService.UpdateTest(testuctDto);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/testucts
        [Route("~/api/tests")]
        [HttpPost]
        public HttpResponseMessage Delete([FromBody]int id)
        {
            try
            {
                testService.DeleteTest(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
