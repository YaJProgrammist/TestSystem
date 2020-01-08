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
    public class AnswerController : Controller
    {
        private IAnswerService answerService;

        public AnswerController(IAnswerService serv)
        {
            answerService = serv;
        }

        // GET api/answeructs
        [Route("~/api/answers")]
        [HttpGet]
        public IEnumerable<AnswerDTO> Get()
        {
            try
            {
                return answerService.GetAnswers((answer) => true);
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

        // GET api/answers/5
        [Route("~/api/answers/{Id}")]
        [HttpGet]
        public AnswerDTO Get(int id)
        {
            try
            {
                return answerService.GetAnswer(id);
            }
            catch (ValidationException ex)
            {
                throw new HttpResponseException { Status = HttpStatusCode.NotFound };
            }
        }

        // POST api/answeructs
        [Route("~/api/answers")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]AnswerDTO answerDto)
        {
            try
            {
                answerService.AddAnswer(answerDto);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/answeructs
        [Route("~/api/answers")]
        [HttpPost]
        public HttpResponseMessage Put([FromBody]AnswerDTO answeructDto)
        {
            try
            {
                answerService.UpdateAnswer(answeructDto);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/answeructs
        [Route("~/api/answers")]
        [HttpPost]
        public HttpResponseMessage Delete([FromBody]int id)
        {
            try
            {
                answerService.DeleteAnswer(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
