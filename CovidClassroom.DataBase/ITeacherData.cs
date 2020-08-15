using CovidClassroom.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.DataBase
{
    public interface ITeacherData
    {
        public Teacher add(Teacher teacher);
        public Teacher delete(Teacher teacher);
        public Teacher update(Teacher newTeacher);
        public Teacher getByIdentityUser(IdentityUser user);
        public int commit();
    }
}
