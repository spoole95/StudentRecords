using StudentRecords.WebApi.Models;
using System.Collections.Generic;

namespace StudentRecords.Web.Models
{
    public class CourseEnrolmentListModel
    {
        public string StudentId { get; set; }
        public List<CourseEnrolmentModel> Courses { get; set; }

    }
}
