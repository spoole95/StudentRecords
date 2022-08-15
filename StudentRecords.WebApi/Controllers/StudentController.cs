using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentRecords.WebApi.Models;
using StudentRecords.WebApi.Repository.Repository;
using System;
using System.Net;

namespace StudentRecords.WebApi.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Returns all students and courses they are enrolled on
        /// </summary>
        /// <response code="200">List of <code>StudentModel</code></response>
        /// <response cref="HttpStatusCode.InternalServerError"></response>
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_studentRepository.Load());
            } catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Get specific student by id
        /// </summary>
        /// <param name="studentId"></param>
        /// <response code="200"><code>StudentModel</code></response>
        /// <response cref="HttpStatusCode.InternalServerError"></response>
        [HttpGet]
        [Route("{studentId}")]
        public IActionResult Get(int studentId)
        {
            try
            {
                var student = _studentRepository.LoadStudent(studentId);
                if (student != null)
                {
                    return Ok(student);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Add student
        /// </summary>
        /// <param name="student"></param>
        /// <response code="HttpStatusCode.NoContent"></response>
        /// <response cref="HttpStatusCode.InternalServerError"></response>
        [HttpPost]
        [Route("")]
        public IActionResult Add(StudentModel student)
        {
            try
            {
                _studentRepository.InsertStudent(student);
                return NoContent();//Could be Created (201) here if we want to give the ref to the student back
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="student">Full student model</param>
        /// <response code="HttpStatusCode.NoContent"></response>
        /// <response cref="HttpStatusCode.InternalServerError"></response>
        [HttpPut]
        [Route("")]
        public IActionResult Update(StudentModel student)
        {
            try
            {
                _studentRepository.UpdateStudent(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Enroll student
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="enrolment"></param>
        /// <response code="HttpStatusCode.NoContent"></response>
        /// <response cref="HttpStatusCode.InternalServerError"></response>
        [HttpPut]
        [Route("Enroll/{studentId}")]
        public IActionResult Enroll(int studentId, CourseEnrolementModel enrolment)
        {
            try
            {
                _studentRepository.EnrolStudent(studentId, enrolment);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
