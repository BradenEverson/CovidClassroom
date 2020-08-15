using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.Core
{
    public class Teacher
    {
        public Teacher(IdentityUser baseUser)
        {
            this.baseUser = baseUser;
            this.classRoom = new List<Student>();
        }
        public IdentityUser baseUser { get; set; }
        public List<Student> classRoom { get; set; }
        
    }
}
