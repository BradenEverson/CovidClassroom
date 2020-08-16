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
            possibleAnswers = new List<string>();
        }
        public string face1;
        public string face2;
        public List<string> possibleAnswers { get; set; }
    }
}
