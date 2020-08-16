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
    public class ClassenvironmentModel : PageModel
    {
        public Classroom currentClass;
        public readonly IClassRoomData classes;
        public readonly IStudentData students;
        public readonly ITeacherData teachers;
        public readonly ApplicationDbContext db;
        public int index = 0;
        public IdentityUser currentUser = new IdentityUser();
        public ClassenvironmentModel(ApplicationDbContext db, IStudentData students, ITeacherData teachers, IClassRoomData classes)
        {
            this.db = db;
            this.students = students;
            this.teachers = teachers;
            this.classes = classes;
        }
        public void OnGet(string classId)
        {
            currentUser = db.Users.FirstOrDefault(r => r.Email == User.Identity.Name);
            currentClass = classes.getByGuid(classId);
        }
        public int AddToIndex()
        {
            index++;
            return index;
        }
        public IActionResult OnPost()
        {
            students.swap(students.getByEmail(User.Identity.Name));
            return RedirectToPage("./Timer", new {time = students.getTime(User.Identity.Name) });
            //return RedirectToPage("./StudentApi", new { studentEmail = "Braden@gmail.com" });
        }
    }
}