using CovidClassroom.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.DataBase
{
    public interface IStudentData
    {
        public Student add(Student Student);
        public Student delete(Student Student);
        public Student update(Student newStudent);
        public Student getByIdentityUser(IdentityUser user);
        public int commit();
    }
}
