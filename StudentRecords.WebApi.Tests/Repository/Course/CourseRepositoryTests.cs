using NUnit.Framework;
using StudentRecords.WebApi.Repository.Course;
using System.Linq;

namespace StudentRecords.WebApi.Tests.Repository.Course
{
    public class CourseRepositoryTests
    {
        [Test]
        public void LoadAll_should_return_all()
        {
            //Arrange
            var repo = new CourseRepository();

            //Act
            var result = repo.Load();

            //Assert
            Assert.That(result.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Load_valid_course_should_return_course()
        {
            //Arrange
            var repo = new CourseRepository();

            //Act
            var result = repo.LoadCourse("UP0000");

            //Assert
            Assert.That(result.CourseCode, Is.EqualTo("UP0000"));
            Assert.That(result.CourseName, Is.EqualTo("Used for testing"));
        }

        [Test]
        public void Load_invalid_course_should_return_null()
        {
            //Arrange
            var repo = new CourseRepository();

            //Act
            var result = repo.LoadCourse("sdf");

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}