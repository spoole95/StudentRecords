using Microsoft.AspNetCore.Mvc;
using System;

namespace StudentRecords.WebApi.Controllers
{
    public class CourseController : Controller
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
    }
}
