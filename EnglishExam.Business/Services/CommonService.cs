using EnglishExam.Business.IServices;
using EnglishExam.Model.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace EnglishExam.Business.Services
{
    public class CommonService : ICommonService
    {
        public string GetWebBlogText(string path)
        {
            if (path != "Bir Başlık Seç")
            {
                if (path.Contains("https://www.wired.com"))
                {
                    path = path.Split("https://www.wired.com")[1];
                }
                List<string> Text = new List<string>();
                Uri urlForText = new Uri("https://www.wired.com" + path);

                WebClient webClientForText = new WebClient();
                string htmlFortext = webClientForText.DownloadString(urlForText);
                HtmlDocument documentForText = new HtmlDocument();
                documentForText.LoadHtml(htmlFortext);
                HtmlNodeCollection htmlNodesForText = documentForText.DocumentNode.SelectNodes("//div[@class='body__inner-container']/p");

                foreach (var node in htmlNodesForText)
                {
                    Text.Add(node.InnerText);
                }
                var result = string.Join(" ", Text);

                return result;
            }
            else
            {
                return "";
            }
        }

        public List<HomePageModel> GetWebsiteData()
        {
            Uri url = new Uri("https://www.wired.com/");

            WebClient webClient = new WebClient();
            string html = webClient.DownloadString(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            HtmlNodeCollection htmlNodes = document.DocumentNode.SelectNodes("//div[@class='summary-item__content']/a");
            List<string> titles = new List<string>();
            List<string> links = new List<string>();

            int counter = 0;
            foreach (var node in htmlNodes)
            {
                if (counter != 5)
                {
                    string link = node.Attributes["href"].Value;
                    if (link.Contains("#"))
                    {
                        link = link.Split("#")[0];
                    }
                    titles.Add(node.InnerText);
                    links.Add(link);
                    counter++;
                }
                else
                {
                    break;
                }

            }

            var resultList = new List<HomePageModel>();
            for (int i = 0; i < links.Count(); i++)
            {
                resultList.Add(new HomePageModel()
                {
                    Title = titles[i],
                    Link = links[i],
                });
            }
            return resultList;
        }
    }
}
