using CovidClassroom.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidClassroom.DataBase
{
    public class TeacherDb : ITeacherData
    {
        private readonly List<Teacher> Teachers;
        public TeacherDb()
        {
            Teachers = new List<Teacher>();
        }
        public Teacher add(Teacher Teacher)
        {
            Teachers.Add(Teacher);
            return Teacher;
        }

        public int commit()
        {
            return 0;
        }

        public Teacher delete(Teacher Teacher)
        {
            Teachers.Remove(Teacher);
            return Teacher;
        }

        public Teacher getByIdentityUser(IdentityUser user)
        {
            Teacher receivedTeacher = Teachers.FirstOrDefault(r => r.baseUser.Email == user.Email);
            return receivedTeacher;
        }

        public Teacher update(Teacher newTeacher)
        {
            Teacher legacyTeacher = Teachers.FirstOrDefault(r => r.baseUser.Email == newTeacher.baseUser.Email);
            if (legacyTeacher != null)
            {
                legacyTeacher.classRoom = newTeacher.classRoom;
            }
            return legacyTeacher;
        }
    }
}
