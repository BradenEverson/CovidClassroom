using CovidClassroom.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.DataBase
{
    public interface IClassRoomData
    {
        public Classroom add(Classroom classroom);
        public Classroom delete(Classroom classroom);
        public Classroom update(Classroom updatedClassroom);
        public Classroom getByGuid(string Guid);
        public int commit();
    }
}
