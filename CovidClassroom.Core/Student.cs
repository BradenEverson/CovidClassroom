using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.Core
{
    public class Student
    {
        public Student(IdentityUser baseUser)
        {
            this.baseUser = baseUser;
            this.hourCounter = 0;
        }
        public IdentityUser baseUser { get; set; }
        public int hourCounter { get; set; }
    }
}
