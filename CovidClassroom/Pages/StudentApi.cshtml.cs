using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidClassroom.Core;
using CovidClassroom.Data;
using CovidClassroom.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CovidClassroom
{
    public class StudentApiModel : PageModel
    {
        public readonly IClassRoomData classes;
        public readonly IStudentData students;
        public readonly ITeacherData teachers;
        public readonly ApplicationDbContext db;
        public IdentityUser currentUser = new IdentityUser();
        public bool isTeacher;
        public StudentApiModel(ApplicationDbContext db, IStudentData students, ITeacherData teachers, IClassRoomData classes)
        {
            this.db = db;
            this.students = students;
            this.teachers = teachers;
            this.classes = classes;
        }
        public IActionResult OnGet(string studentEmail)
        {
            Student student = students.getByEmail(studentEmail);
            return (student != null && student.enabled != false) ? Content(student.hourCounter.ToString()) : Content("Get out of here");
            
        }
    }
}