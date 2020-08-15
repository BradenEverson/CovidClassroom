using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.Core
{
    public class Student
    {
        public IdentityUser baseUser { get; set; }
        public int hourCounter { get; set; }
    }
}
