using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidClassroom.Data;
using CovidClassroom.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CovidClassroom
{
    public class ClassRoomManagerModel : PageModel
    {
        public readonly IClassRoomData classes;
        public readonly IStudentData students;
        public readonly ITeacherData teachers;
        public readonly ApplicationDbContext db;
        public IdentityUser currentUser = new IdentityUser();
        public bool isTeacher;
        public ClassRoomManagerModel(ApplicationDbContext db, IStudentData students, ITeacherData teachers, IClassRoomData classes)
        {
            this.db = db;
            this.students = students;
            this.teachers = teachers;
            this.classes = classes;
        }
        public void OnGet()
        {
            currentUser = db.Users.FirstOrDefault(r => r.Email == User.Identity.Name);
            Console.WriteLine(currentUser.Email);
            isTeacher = (teachers.getByIdentityUser(currentUser) != null);
        }
        public void OnPost()
        {

        }
    }
}