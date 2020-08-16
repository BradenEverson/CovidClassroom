using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CovidClassroom.Core
{
    public class Classroom
    {
        public Classroom(string owner, string url, string name, string guid, List<Student> students)
        {
            this.classroomId = guid;
            this.cardset = scrapeQuizlet(url);
            this.students = students;
            this.className = name;
            this.ownerEmail = owner.Replace(Environment.NewLine,String.Empty);
            Console.WriteLine("Teacher Email: " + this.ownerEmail);
            foreach(flashCard card in this.cardset)
            {
                card.possibleAnswers.Add(cardset[StaticRandom.Instance.Next(0, cardset.Count() - 1)].face2);
                Console.WriteLine(card.possibleAnswers[0]);
                card.possibleAnswers.Add(cardset[StaticRandom.Instance.Next(0, cardset.Count() - 1)].face2);
                Console.WriteLine(card.possibleAnswers[1]);
                card.possibleAnswers.Add(cardset[StaticRandom.Instance.Next(0, cardset.Count() - 1)].face2);
                Console.WriteLine(card.possibleAnswers[2]);
                card.possibleAnswers.Add(card.face2);
                Console.WriteLine(card.possibleAnswers[3]);
                Shuffle(card.possibleAnswers);
            }
        }
        public string ownerEmail { get; }
        public string classroomId { get; }
        public string className { get; set; }
        public IdentityUser owner { get; }
        public List<Student> students { get; set; }
        public List<flashCard> cardset { get; set; }
        private static List<flashCard> scrapeQuizlet(string url)
        {
            List<flashCard> cards = new List<flashCard>();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "CovidClassroom");
            var html = httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html.Result);
            var setsList = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("SetPageTerms-term")).ToList();
            for (int i = 2; i < setsList.Count(); i++)
            {
                string term = setsList[i].Descendants("div")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Contains("SetPageTerm-sideContent")).ToList()[0].InnerText;
                string definition = setsList[i].Descendants("div")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Contains("SetPageTerm-sideContent")).ToList()[1].InnerText;
                flashCard card = new flashCard(term, definition);
                cards.Add(card);
            }
            return cards;
        }
        public void Shuffle(List<string> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = StaticRandom.Instance.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
