using StudentRecords.WebApi.Models;
using System.Collections.Generic;

namespace StudentRecords.WebApi.Repository.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> Load();
        StudentModel LoadStudent(int id);
        void InsertStudent(StudentModel student);
        void UpdateStudent(StudentModel student);
        void EnrolStudent(int studentId, CourseEnrolmentModel enrolment);
    }
}
