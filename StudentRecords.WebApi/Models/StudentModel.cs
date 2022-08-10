using System;
using System.Collections.Generic;

namespace StudentRecords.WebApi.Models
{
    public class StudentModel
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string KnownAs { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char? Gender { get; set; }
        public string UniversityEmail { get; set; }
        public string NetworkId { get; set; }
        public char? HomeOrOverseas { get; set; }
        public IEnumerable<CourseEnrolementModel> CourseEnrolment { get; set; }
    }
}
