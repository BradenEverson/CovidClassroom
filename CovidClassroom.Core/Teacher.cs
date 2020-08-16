using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.Core
{
    public class Teacher
    {
        public Teacher(IdentityUser baseUser, string Email)
        {
            this.baseUser = new IdentityUser()
            {
                Email = baseUser.Email
            };
            this.classRoom = new List<Student>();
            this.Email = Email;
        }
        public IdentityUser baseUser { get; set; }
        public List<Student> classRoom { get; set; }
        public String Email { get; set; }
        
    }
}
