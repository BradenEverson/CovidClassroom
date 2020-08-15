using CovidClassroom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidClassroom.DataBase
{
    public class ClassDb : IClassRoomData
    {
        private readonly List<Classroom> classrooms;
        public ClassDb()
        {
            classrooms = new List<Classroom>();
        }

        public Classroom add(Classroom classroom)
        {
            classrooms.Add(classroom);
            return classroom;
        }

        public int commit()
        {
            return 0;
        }

        public Classroom delete(Classroom classroom)
        {
            classrooms.Remove(classroom);
            return classroom;
        }

        public Classroom getByGuid(string Guid)
        {
            Classroom classroom = classrooms.FirstOrDefault(r => r.classroomId == Guid);
            return (classroom != null) ? classroom : null;

        }

        public Classroom update(Classroom updatedClassroom)
        {
            Classroom legacyClassroom = classrooms.FirstOrDefault(r => r.classroomId == updatedClassroom.classroomId);
            if(legacyClassroom != null)
            {
                legacyClassroom.students = updatedClassroom.students;
            }
        }
    }
}
