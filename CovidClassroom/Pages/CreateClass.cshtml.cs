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
    public class CreateClassModel : PageModel
    {
        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string url { get; set; }
        [BindProperty]
        public string studentEmail { get; set; }
        public readonly IClassRoomData classes;
        public readonly IStudentData students;
        public readonly ITeacherData teachers;
        public readonly ApplicationDbContext db;
        public IdentityUser currentUser = new IdentityUser();
        public List<Student> studentsList = new List<Student>();
        public string customGuid;
        public CreateClassModel(ApplicationDbContext db, IStudentData students, ITeacherData teachers, IClassRoomData classes)
        {
            this.db = db;
            this.students = students;
            this.teachers = teachers;
            this.classes = classes;
            customGuid = Guid.NewGuid().ToString().Split('-')[0];
        }
        public IActionResult OnGet()
        {
            currentUser = db.Users.FirstOrDefault(r => r.Email == User.Identity.Name);
            if(teachers.getByIdentityUser(currentUser) == null)
            {
                return RedirectToPage("./index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Console.WriteLine("Url: " + url);
            Classroom newClass = new Classroom(teachers.getByIdentityUser(currentUser), url, name, customGuid);
            newClass.students = classes.getStudents(customGuid);
            classes.add(newClass);
            return RedirectToPage("./ClassRoomManager");
        }
    }
}