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
    public class QuestionController : Controller
    {
        private IQuestionService questionService;

        public QuestionController(IQuestionService serv)
        {
            questionService = serv;
        }

        // GET api/questionucts
        [Route("~/api/questions")]
        [HttpGet]
        public IEnumerable<QuestionDTO> Get()
        {
            try
            {
                return questionService.GetQuestions((question) => true);
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

        // GET api/questions/5
        [Route("~/api/questions/{Id}")]
        [HttpGet]
        public QuestionDTO Get(int id)
        {
            try
            {
                return questionService.GetQuestion(id);
            }
            catch (ValidationException ex)
            {
                throw new HttpResponseException { Status = HttpStatusCode.NotFound };
            }
        }

        // POST api/questionucts
        [Route("~/api/questions")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]QuestionDTO questionDto)
        {
            try
            {
                questionService.AddQuestion(questionDto);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/questionucts
        [Route("~/api/questions")]
        [HttpPost]
        public HttpResponseMessage Put([FromBody]QuestionDTO questionuctDto)
        {
            try
            {
                questionService.UpdateQuestion(questionuctDto);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/questionucts
        [Route("~/api/questions")]
        [HttpPost]
        public HttpResponseMessage Delete([FromBody]int id)
        {
            try
            {
                questionService.DeleteQuestion(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
