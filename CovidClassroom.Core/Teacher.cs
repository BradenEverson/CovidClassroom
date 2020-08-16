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
            this.classRoom = new List<Student>();
            this.Email = Email;
            Console.WriteLine("Teacher email: " + Email);
        }
        public IdentityUser baseUser { get; set; }
        public List<Student> classRoom { get; set; }
        public String Email { get; set; }
        
    }
}
