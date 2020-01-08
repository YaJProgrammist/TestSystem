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
    public class StudentController : Controller
    {
        private IStudentService studentService;

        public StudentController(IStudentService serv)
        {
            studentService = serv;
        }

        // GET api/studentucts
        [Route("~/api/students")]
        [HttpGet]
        public IEnumerable<StudentDTO> Get()
        {
            try
            {
                return studentService.GetStudents((student) => true);
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

        // GET api/students/5
        [Route("~/api/students/{Id}")]
        [HttpGet]
        public StudentDTO Get(int id)
        {
            try
            {
                return studentService.GetStudent(id);
            }
            catch (ValidationException ex)
            {
                throw new HttpResponseException { Status = HttpStatusCode.NotFound };
            }
        }

        // POST api/studentucts
        [Route("~/api/students")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]StudentDTO studentDto)
        {
            try
            {
                studentService.AddStudent(studentDto);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/studentucts
        [Route("~/api/students")]
        [HttpPost]
        public HttpResponseMessage Put([FromBody]StudentDTO studentuctDto)
        {
            try
            {
                studentService.UpdateStudent(studentuctDto);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/studentucts
        [Route("~/api/students")]
        [HttpPost]
        public HttpResponseMessage Delete([FromBody]int id)
        {
            try
            {
                studentService.DeleteStudent(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
