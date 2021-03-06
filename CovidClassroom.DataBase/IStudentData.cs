﻿using CovidClassroom.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.DataBase
{
    public interface IStudentData
    {
        public Student add(Student Student);
        public Student delete(Student Student);
        public Student update(Student newStudent);
        public Student getByIdentityUser(IdentityUser user);
        public int commit();
        public void swap(Student student);
        public Student getByEmail(string email);
        public void addMinutesToStudent(string student, int amount);
        public int getTime(string email);
    }
}
