using Microsoft.AspNetCore.Mvc;
using StudentRecords.WebApi.Repository.Course;
using System;
using System.Net;

namespace StudentRecords.WebApi.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_courseRepository.Load());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(string courseCode)
        {
            try
            {
                var course = _courseRepository.LoadCourse(courseCode);
                if (course != null)
                {
                    return Ok(course);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
