using NUnit.Framework;
using StudentRecords.WebApi.Repository.Repository;
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
            Assert.IsTrue(result.All(x => int.TryParse(x.StudentId, out var i)));
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
    }
}
