using CovidClassroom.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidClassroom.DataBase
{
    public class ClassDb : IClassRoomData
    {
        private readonly List<Classroom> classrooms;
        public ClassDb()
        {
            classrooms = new List<Classroom>();
        }

        public Classroom add(Classroom classroom)
        {
            classrooms.Add(classroom);
            return classroom;
        }

        public int commit()
        {
            return 0;
        }

        public Classroom delete(Classroom classroom)
        {
            classrooms.Remove(classroom);
            return classroom;
        }

        public List<Classroom> getAllByStudent(IdentityUser student)
        {
            List<Classroom> classroomsWithStudent = classrooms.Where(r => r.students.FirstOrDefault(f => f.baseUser.Email == student.Email) != null).ToList();
            return classroomsWithStudent;
        }

        public List<Classroom> getAllByTeacher(IdentityUser teacher)
        {
            List<Classroom> classroomsWithTeacher = classrooms.Where(r => r.owner.Email == teacher.Email).ToList();
            return classroomsWithTeacher;
        }

        public Classroom getByGuid(string Guid)
        {
            Classroom classroom = classrooms.FirstOrDefault(r => r.classroomId == Guid);
            return (classroom != null) ? classroom : null;

        }

        public Classroom update(Classroom updatedClassroom)
        {
            Classroom legacyClassroom = classrooms.FirstOrDefault(r => r.classroomId == updatedClassroom.classroomId);
            if(legacyClassroom != null)
            {
                legacyClassroom.students = updatedClassroom.students;
            }
            return legacyClassroom;
        }
    }
}
