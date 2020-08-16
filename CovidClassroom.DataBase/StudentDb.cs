using CovidClassroom.Core;
using Microsoft.AspNetCore.Identity;
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
            students = new List<Student>()
            {
                new Student("Braden@gmail.com")
            };
        }
        public Student add(Student Student)
        {
            students.Add(Student);
            return Student;
        }
        public void swap(Student student)
        {
            students.FirstOrDefault(r => r.Email == student.Email).enabled = !students.FirstOrDefault(r => r.Email == student.Email).enabled;
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
            Student receivedStudent = students.FirstOrDefault(r => r.Email == user.Email);
            return receivedStudent;
        }
        public Student getByEmail(string email)
        {
            Student receivedStudent = students.FirstOrDefault(r => r.Email == email);
            return receivedStudent;
        }
        public Student update(Student newStudent)
        {
            Student legacyStudent = students.FirstOrDefault(r => r.Email == newStudent.Email);
            if(legacyStudent != null)
            {
                legacyStudent.hourCounter = newStudent.hourCounter;
            }
            return legacyStudent;
        }

        public void addMinutesToStudent(string student, int amount)
        {
            getByEmail(student).hourCounter += amount;
        }

        public int getTime(string email)
        {
            return getByEmail(email).hourCounter;
        }
    }
}
