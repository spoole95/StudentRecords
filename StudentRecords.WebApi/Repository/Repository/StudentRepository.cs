using StudentRecords.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRecords.WebApi.Repository.Repository
{
    public class StudentRepository : JsonRepository, IStudentRepository
    {
        public StudentRepository() : base(@"..\..\..\..\Data\students.json")
        {
        }

        public void EnrolStudent(int studentId, CourseEnrolemntModel enrolment)
        {
            throw new System.NotImplementedException();
        }

        public void InsertStudent(StudentModel student)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<StudentModel> Load()
        {
            return Get<IEnumerable<StudentModel>>();
        }

        public StudentModel LoadStudent(int id)
        {
            return Load().SingleOrDefault(x => int.Parse(x.StudentId) == id);
        }

        public void UpdateStudent(StudentModel student)
        {
            throw new System.NotImplementedException();
        }
    }
}
