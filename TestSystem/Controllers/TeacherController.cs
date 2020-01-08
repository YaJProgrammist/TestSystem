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
    public class TeacherController : Controller
    {
        private ITeacherService teacherService;

        public TeacherController(ITeacherService serv)
        {
            teacherService = serv;
        }

        // GET api/teacheructs
        [Route("~/api/teachers")]
        [HttpGet]
        public IEnumerable<TeacherDTO> Get()
        {
            try
            {
                return teacherService.GetTeachers((teacher) => true);
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

        // GET api/teachers/5
        [Route("~/api/teachers/{Id}")]
        [HttpGet]
        public TeacherDTO Get(int id)
        {
            try
            {
                return teacherService.GetTeacher(id);
            }
            catch (ValidationException ex)
            {
                throw new HttpResponseException { Status = HttpStatusCode.NotFound };
            }
        }

        // POST api/teacheructs
        [Route("~/api/teachers")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]TeacherDTO teacherDto)
        {
            try
            {
                teacherService.AddTeacher(teacherDto);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/teacheructs
        [Route("~/api/teachers")]
        [HttpPost]
        public HttpResponseMessage Put([FromBody]TeacherDTO teacheructDto)
        {
            try
            {
                teacherService.UpdateTeacher(teacheructDto);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/teacheructs
        [Route("~/api/teachers")]
        [HttpPost]
        public HttpResponseMessage Delete([FromBody]int id)
        {
            try
            {
                teacherService.DeleteTeacher(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
