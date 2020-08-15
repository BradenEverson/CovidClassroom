using CovidClassroom.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.DataBase
{
    public interface IClassRoomData
    {
        public void addKeyValPair(string id, List<Student> students);
        public void addStudentToKey(String id, Student student);
        public List<Student> getStudents(string id);
        public Classroom add(Classroom classroom);
        public Classroom delete(Classroom classroom);
        public Classroom update(Classroom updatedClassroom);
        public Classroom getByGuid(string Guid);
        public List<Classroom> getAllByStudent(IdentityUser student);
        public List<Classroom> getAllByTeacher(IdentityUser teacher);
        public int commit();
    }
}
