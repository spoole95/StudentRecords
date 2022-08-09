using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecords.WebApi.Models;
using System;

namespace StudentRecords.WebApi.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Get(int studentId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Add(StudentModel student)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Update(StudentModel student)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Enroll(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
