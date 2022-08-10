using StudentRecords.WebApi.Models;
using System.Collections.Generic;

namespace StudentRecords.WebApi.Repository.Course
{
    public interface ICourseRepository
    {
        CourseModel LoadCourse(string courseCode);
        IEnumerable<CourseModel> Load();
    }
}
