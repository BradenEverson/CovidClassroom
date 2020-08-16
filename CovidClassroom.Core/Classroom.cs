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
            this.ownerEmail = owner;
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
    }
}
