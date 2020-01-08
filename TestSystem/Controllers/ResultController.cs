using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TestSystem.Infrastructure;

namespace TestSystem.Controllers
{
    public class ResultController : Controller
    {
        private IResultService resultService;

        public ResultController(IResultService serv)
        {
            resultService = serv;
        }

        // GET api/resultucts
        [Route("~/api/results")]
        [HttpGet]
        public IEnumerable<ResultDTO> Get()
        {
            try
            {
                return resultService.GetResults((result) => true);
            }
            catch (ValidationException ex)
            {
                throw new HttpResponseException { Status = HttpStatusCode.NotFound };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException { Status = HttpStatusCode.InternalServerError };
            }
        }

        // GET api/results/5
        [Route("~/api/results/{Id}")]
        [HttpGet]
        public ResultDTO Get(int id)
        {
            try
            {
                return resultService.GetResult(id);
            }
            catch (ValidationException ex)
            {
                throw new HttpResponseException { Status = HttpStatusCode.NotFound };
            }
        }

        // POST api/resultucts
        [Route("~/api/results")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ResultDTO resultDto)
        {
            try
            {
                resultService.AddResult(resultDto);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/resultucts
        [Route("~/api/results")]
        [HttpPost]
        public HttpResponseMessage Put([FromBody]ResultDTO resultuctDto)
        {
            try
            {
                resultService.UpdateResult(resultuctDto);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/resultucts
        [Route("~/api/results")]
        [HttpPost]
        public HttpResponseMessage Delete([FromBody]int id)
        {
            try
            {
                resultService.DeleteResult(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
