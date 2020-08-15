using System;
using System.Collections.Generic;
using System.Text;

namespace CovidClassroom.Core
{
    public class flashCard
    {
        public flashCard(string tempTerm, string tempDefinition)
        {
            face1 = tempTerm;
            face2 = tempDefinition;
        }
        public string face1;
        public string face2;
    }
}
