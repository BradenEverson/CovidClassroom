using CovidClassroom.Core;
using CovidClassroom.Data;
using CovidClassroom.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidClassroom
{
    public class ClassHub : Hub
    {
        public readonly IClassRoomData classes;
        public readonly IStudentData students;
        public readonly ITeacherData teachers;
        public readonly ApplicationDbContext db;
        public ClassHub(ApplicationDbContext db, IStudentData students, ITeacherData teachers, IClassRoomData classes)
        {
            this.db = db;
            this.students = students;
            this.teachers = teachers;
            this.classes = classes;
        }
        public async Task SendClassBoundStudent(string id, string studentName)
        {
            IdentityUser currentUser = db.Users.FirstOrDefault(r => r.Email == studentName);
            if(currentUser != null)
            {
                Student addedStudent = students.getByIdentityUser(currentUser);
                if(addedStudent != null)
                {
                    classes.addStudentToKey(id, addedStudent);
                }
            }
            await Clients.Caller.SendAsync("StudentAdded", id);
        }
    }
}