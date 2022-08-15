using NUnit.Framework;
using StudentRecords.WebApi.Models;
using StudentRecords.WebApi.Repository.Repository;
using System;
using System.Linq;

namespace StudentRecords.WebApi.Tests.Repository.Student
{
    public class StudentRepositoryTests
    {
        private IStudentRepository _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new StudentRepository("Data/students.json");
        }


        [Test]
        public void LoadAll_should_return_all()
        {
            //Arrange
            //Act
            var result = _repo.Load();

            //Assert
            Assert.That(result.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Load_valid_student_should_return_course()
        {
            //Arrange
            //Act
            var result = _repo.LoadStudent(77777702);

            //Assert
            Assert.That(result.StudentId, Is.EqualTo("77777702"));
            Assert.That(result.LastName, Is.EqualTo("Test 02"));
        }

        [Test]
        public void Load_invalid_student_should_return_null()
        {
            //Arrange
            //Act
            var result = _repo.LoadStudent(0);

            //Assert
            Assert.That(result, Is.Null);
        }


        [Test]
        public void Update_should_update_single_record()
        {
            //Arrange
            var student = _repo.LoadStudent(77777703);

            var updatedEmail = Guid.NewGuid().ToString(); //Going to unique most of the time (2^128), so won't be what was here last time the test was ran!.
            student.UniversityEmail = updatedEmail;

            //Act
            _repo.UpdateStudent(student);

            //Assert
            var updatedStudent = _repo.LoadStudent(77777703);

            Assert.That(updatedEmail, Is.EqualTo(updatedStudent.UniversityEmail));
        }

        [Test]
        public void Insert_should_create_record()
        {
            //Arrange
            var student = new StudentModel
            {
                FirstName = "Unit",
                LastName = "Test",
                KnownAs = Guid.NewGuid().ToString(),
                DisplayName = "UTest",
                DateOfBirth = DateTime.Now.Date,
                Gender = "N",
                UniversityEmail = "Unit.test@mail.ac.uk",
                NetworkId = "3324/3243",
                HomeOrOverseas = 'C'
            };

            //Act
            _repo.InsertStudent(student);

            //Assert
            var list = _repo.Load();

            Assert.That(list.SingleOrDefault(x => x.KnownAs == student.KnownAs), Is.Not.Null);
        }

        [Test]
        public void Enroll_student_should_add_course_and_id()
        {
            //Arrange
            var enrolment = new CourseEnrolmentModel
            {
                EnrolmentId = "77777709/2",
                AcademicYear = "2020/2",
                YearOfStudy = "1",
                Occurrence = "JAN2S",
                ModeOfAttendance = "FULL TIME",
                EnrolmentStatus = "E",
                CourseEntryDate = new DateTime(2020, 7, 17),
                ExpectedEndDate = new DateTime(2020, 8, 4),
                Course = new CourseModel
                {
                    CourseCode = "PT0129Z",
                    CourseName = "MA Interior Design (extended) (BCUIC)"
                }
            };

            //Act
            _repo.EnrolStudent(77777709, enrolment);

            //Assert
            var student = _repo.LoadStudent(77777709);

            Assert.That(student.CourseEnrolment.Count, Is.EqualTo(2));
            Assert.That(student.CourseEnrolment.SingleOrDefault(x => x.EnrolmentId == "77777709/2"), Is.Not.Null);
            Assert.That(student.CourseEnrolment.SingleOrDefault(x => x.Course.CourseCode == "PT0129Z"), Is.Not.Null);
        }
    }
}
