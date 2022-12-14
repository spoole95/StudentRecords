using StudentRecords.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRecords.WebApi.Repository.Repository
{
    public class StudentRepository : JsonRepository, IStudentRepository
    {
        public StudentRepository() : base(@"..\Data\students.json")
        {
        }

        public StudentRepository(string repositoryUrl) : base(repositoryUrl)
        {
        }

        public void EnrolStudent(int studentId, CourseEnrolmentModel enrolment)
        {
            var student = LoadStudent(studentId);

            //TODO - Generate enrolmentId string? {studentId}/{sesquence}

            student.CourseEnrolment = student.CourseEnrolment.Append(enrolment);

            UpdateStudent(student);
        }

        public void InsertStudent(StudentModel student)
        {
            var exisingList = Load();

            if (!string.IsNullOrEmpty(student.StudentId) &&
                exisingList.Any(x => x.StudentId == student.StudentId))
            {
                //Catch student already existing
                throw new ArgumentException("Student already exists");
            }
            if (string.IsNullOrEmpty(student.StudentId))
            {
                //Generate new id
                student.StudentId = (exisingList.Max(x => int.Parse(x.StudentId)) + 1).ToString();
            }

            exisingList = exisingList.Append(student);

            UpdateList(exisingList);
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
            var existingList = Load();

            //TODO - does not exist exception?

            foreach (var existingStudent in existingList)
            {
                if (existingStudent.StudentId != student.StudentId) continue;

                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.KnownAs = student.KnownAs;
                existingStudent.DisplayName = student.DisplayName;
                existingStudent.DateOfBirth = student.DateOfBirth;
                existingStudent.Gender = student.Gender;
                existingStudent.UniversityEmail = student.UniversityEmail;
                existingStudent.NetworkId = student.NetworkId;
                existingStudent.HomeOrOverseas = student.HomeOrOverseas;
                existingStudent.CourseEnrolment = student.CourseEnrolment ?? existingStudent.CourseEnrolment; //Only update if not null
                break;
            }

            UpdateList(existingList);
        }
    }
}