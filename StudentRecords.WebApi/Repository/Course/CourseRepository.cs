using StudentRecords.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRecords.WebApi.Repository.Course
{
    public class CourseRepository : JsonRepository, ICourseRepository
    {
        public CourseRepository(): base(@"..\..\..\..\Data\Courses.json")
        {
        }

        public IEnumerable<CourseModel> Load()
        {
            return Get<IEnumerable<CourseModel>>();
        }


        public CourseModel LoadCourse(string courseCode)
        {
            //TODO - works, but inefficient to load all if we don't need to.
            return Load().SingleOrDefault(x => x.CourseCode == courseCode);
        }
    }
}
