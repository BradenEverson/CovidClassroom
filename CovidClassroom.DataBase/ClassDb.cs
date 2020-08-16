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
        private readonly Dictionary<string, List<Student>> idStudentPairs;

        private readonly List<Classroom> classrooms;
        public ClassDb()
        {
            classrooms = new List<Classroom>();
            idStudentPairs = new Dictionary<string, List<Student>>();
        }
        public void addKeyValPair(string id, List<Student> students)
        {
            idStudentPairs.Add(id, students);
        }
        public void addStudentToKey(string id, Student student)
        {
            List<Student> students;
            if(idStudentPairs.TryGetValue(id,out students))
            {
                idStudentPairs[id].Add(student);
            }
            else
            {
                idStudentPairs.Add(id, new List<Student>() { student });
            }
        }
        public List<Student> getStudents(string id)
        {
            return (idStudentPairs.TryGetValue(id, out List<Student> throwaway)) ? idStudentPairs[id] : null;
        }
        public Classroom add(Classroom classroom)
        {
            classrooms.Add(classroom);
            Console.WriteLine("Class created by " + classroom.ownerEmail + "!");
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

        public List<Classroom> getAllByStudent(string student)
        {
            List<Classroom> classroomsWithStudent = classrooms.Where(r => r.students.FirstOrDefault(f => f.Email.Contains(student.Split('@')[0])) != null).ToList();
            return classroomsWithStudent;
        }

        public List<Classroom> getAllByTeacher(string teacher)
        {
            List<Classroom> classroomsWithTeacher = classrooms.Where(r => r.ownerEmail.Contains(teacher.Split('@')[0])).ToList();
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

        public flashCard nextCard(string guid)
        {
            flashCard tempCard = getByGuid(guid).cardset[0];
            getByGuid(guid).cardset.Remove(tempCard);
            getByGuid(guid).cardset.Add(tempCard);
            return getByGuid(guid).cardset[0];
        }
    }
}
