using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CovidClassroom.Core
{
    public class Classroom
    {
        public Classroom(Teacher owner, string url)
        {
            this.classroomId = Guid.NewGuid().ToString().Split('-')[0];
            this.cardset = scrapeQuizlet(url);
            this.owner = owner.baseUser;
            this.students = owner.classRoom;
        }
        public string classroomId { get; }
        public IdentityUser owner { get; }
        public List<Student> students { get; set; }
        public List<flashCard> cardset { get; set; }
        private static List<flashCard> scrapeQuizlet(string url)
        {
            List<flashCard> cards = new List<flashCard>();
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html.Result);
            var quizletsList = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("UILinkBox-link")).ToList();
            String setUrl = quizletsList[0].InnerHtml.Split('"')[5];
            httpClient = new HttpClient();
            html = httpClient.GetStringAsync(setUrl);
            htmlDocument = new HtmlAgilityPack.HtmlDocument();
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
