﻿using System;
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
    public class ClassroomModel : PageModel
    {
        public readonly IClassRoomData classes;
        public readonly IStudentData students;
        public readonly ITeacherData teachers;
        public readonly ApplicationDbContext db;
        public IdentityUser currentUser = new IdentityUser();
        public Classroom currentClass;
        public ClassroomModel(ApplicationDbContext db, IStudentData students, ITeacherData teachers, IClassRoomData classes)
        {
            this.db = db;
            this.students = students;
            this.teachers = teachers;
            this.classes = classes;
        }
        public IActionResult OnGet(string classId)
        {
            currentUser = db.Users.FirstOrDefault(r => r.Email == User.Identity.Name);
            currentClass = classes.getByGuid(classId);
            if (currentClass == null)
            {
                return RedirectToPage("./index");
            }
            else if (currentClass.students.FirstOrDefault(r => r.baseUser.Email == currentUser.Email) == null)
            {
                return RedirectToPage("./index");
            }
            return Page();
        }
    }
}