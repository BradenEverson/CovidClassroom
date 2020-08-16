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
        public async Task Answer(string answer, string correct,string guid, string email)
        {
            Console.WriteLine("Gave: " + answer + " as an answer, correct answer is " + correct);
            if(answer == correct)
            {
                flashCard newCard = classes.nextCard(guid);
                students.addMinutesToStudent(email, 15);
                await Clients.Caller.SendAsync("Correct",newCard.face1,newCard.possibleAnswers[0],newCard.possibleAnswers[1],newCard.possibleAnswers[2],newCard.possibleAnswers[3],newCard.face2,guid,email); // Correct(face1, ans1, ans2, ans3, ans4, correct)
            }
            else
            {
                await Clients.Caller.SendAsync("Incorrect");
            }
        }
    }
}