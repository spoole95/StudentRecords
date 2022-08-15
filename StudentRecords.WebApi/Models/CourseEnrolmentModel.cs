using System;

namespace StudentRecords.WebApi.Models
{
    public class CourseEnrolmentModel
    {
        public string EnrolmentId { get; set; }
        public string AcademicYear { get; set; }
        public string YearOfStudy { get; set; }
        public string Occurrence { get; set; }
        public string ModeOfAttendance { get; set; }
        public string EnrolmentStatus { get; set; }
        public DateTime CourseEntryDate { get; set; }
        public DateTime? ExpectedEndDate { get; set; }
        public CourseModel Course { get; set; }
    }
}