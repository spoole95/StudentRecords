using NUnit.Framework;
using StudentRecords.WebApi.Models;
using StudentRecords.WebApi.Repository.Repository;
using System;
using System.Linq;

namespace StudentRecords.WebApi.Tests.Repository.Student
{
    public class StudentRepositoryTests
    { 

        [Test]
        public void LoadAll_should_return_all()
        {
            //Arrange
            var repo = new StudentRepository();

            //Act
            var result = repo.Load();

            //Assert
            Assert.That(result.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Load_valid_course_should_return_course()
        {
            //Arrange
            var repo = new StudentRepository();

            //Act
            var result = repo.LoadStudent(77777702);

            //Assert
            Assert.That(result.StudentId, Is.EqualTo("77777702"));
            Assert.That(result.LastName, Is.EqualTo("Test 02"));
        }

        [Test]
        public void Load_invalid_course_should_return_null()
        {
            //Arrange
            var repo = new StudentRepository();

            //Act
            var result = repo.LoadStudent(0);

            //Assert
            Assert.That(result, Is.Null);
        }


        [Test]
        public void Update_should_update_single_record()
        {
            //Arrange
            var repo = new StudentRepository();

            var student = repo.LoadStudent(77777703);

            var updatedEmail = Guid.NewGuid().ToString(); //Going to unique most of the time (2^128), so won't be what was here last time the test was ran!.
            student.UniversityEmail = updatedEmail;

            //Act
            repo.UpdateStudent(student);

            //Assert
            var updatedStudent = repo.LoadStudent(77777703);

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
                Gender = 'N',
                UniversityEmail = "Unit.test@mail.ac.uk",
                NetworkId = "3324/3243",
                HomeOrOverseas = 'C'
            };

            var repo = new StudentRepository();

            //Act
            repo.InsertStudent(student);

            //Assert
            var list = repo.Load();

            Assert.That(list.SingleOrDefault(x => x.KnownAs == student.KnownAs), Is.Not.Null);
        }


        //TODO - enrolment status not saving properly
    }
}
