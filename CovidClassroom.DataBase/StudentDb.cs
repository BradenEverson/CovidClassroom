using CovidClassroom.Core;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidClassroom.DataBase
{
    public class StudentDb : IStudentData
    {
        private readonly List<Student> students;
        public StudentDb()
        {
            students = new List<Student>();
        }
        public Student add(Student Student)
        {
            students.Add(Student);
            return Student;
        }

        public int commit()
        {
            return 0;
        }

        public Student delete(Student Student)
        {
            students.Remove(Student);
            return Student;
        }

        public Student getByIdentityUser(IdentityUser user)
        {
            Student receivedStudent = students.FirstOrDefault(r => r.baseUser.Email == user.Email);
            return receivedStudent;
        }

        public Student update(Student newStudent)
        {
            Student legacyStudent = students.FirstOrDefault(r => r.baseUser.Email == newStudent.baseUser.Email);
            if(legacyStudent != null)
            {
                legacyStudent.hourCounter = newStudent.hourCounter;
            }
            return legacyStudent;
        }
    }
}
