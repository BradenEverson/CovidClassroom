using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.Core
{
    public class Student
    {
        public Student(string Email,IdentityUser baseUser = null)
        {
            this.hourCounter = 0;
            this.Email = Email;
        }
        public IdentityUser baseUser { get; set; }
        public string Email { get; set; }
        public int hourCounter { get; set; }
    }
}
