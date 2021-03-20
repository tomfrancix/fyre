using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Text;
using Fyre.Console.Data.Descriptor;
using Fyre.Console.Data.Model;
using Fyre.Console.Functions;
using Fyre.Console.Repository;

namespace Fyre.Console.Command
{
    public class ScraperNews
    {
        public static void Execute()
        {
            Print.Color("yellow", "Scraping BBC UK news...");
            System.Console.WriteLine("How many days retrospectively?");
            var daysString = System.Console.ReadLine();
            var daysInput = Convert.ToInt32(daysString);

            ScrapeWebsite(daysInput);

        }
        private static string Title { get; set; }
        private static string Url { get; set; }

        internal static async void ScrapeWebsite(int daysInput)
        { 
            string siteUrl = "http://feeds.bbci.co.uk/news/rss.xml";
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();
            var request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(response);

            GetScrapeResults(document, daysInput);

            Startup.Introduction();
        }

        private static void GetScrapeResults(IHtmlDocument document, int daysInput)
        {
            IEnumerable<IElement> articleLink = document.All;

            if (articleLink.Any())
            {
                PrintResults(articleLink, daysInput);
            }
        }
        public static void PrintResults(IEnumerable<IElement> articleLink, int daysInput)
        {
            var cacheDate = "asdfsadf";

            var days = 0;
            foreach (var element in articleLink)
            {
                if (days >= daysInput) break;

                if (element.TagName == "ITEM")
                {
                    var title = element.GetElementsByTagName("title")[0].Text();
                    if (title.EndsWith("]]>"))
                    {
                        title = title.Substring(0, title.Length - 3);
                    }
                    if (title.StartsWith("<![CDATA["))
                    {
                        title = title.Substring(9);
                    }
                    if (title.EndsWith("]]-->"))
                    {
                        title = title.Substring(0, title.Length - 5);
                    }
                    if (title.StartsWith("<!--[CDATA["))
                    {
                        title = title.Substring(11);
                    }

                    var description = element.InnerHtml.Split("<description>")[1];
                    description = description.Split("</description>")[0];
                    if (description.EndsWith("]]>"))
                    {
                        description = description.Substring(0, title.Length - 3);
                    }
                    if (description.StartsWith("<![CDATA["))
                    {
                        description = description.Substring(9);
                    }
                    if (description.EndsWith("]]-->"))
                    {
                        description = description.Substring(0, description.Length - 5);
                    }
                    if (description.StartsWith("<!--[CDATA["))
                    {
                        description = description.Substring(11);
                    }

                    var link = element.InnerHtml.Split("<guid ispermalink=\"true\">")[1];
                    link = link.Split("</guid>")[0];

                    var date = element.GetElementsByTagName("pubDate")[0].Text().Substring(0, 8);
                    if (date != cacheDate)
                    {
                        Print.Color("grey", "\n" + element.GetElementsByTagName("pubDate")[0].Text() + "\n");
                        cacheDate = date;
                        days++;
                    }
                    Print.Color("blue", " > " + title);
                    System.Console.WriteLine("   " + description);
                    Print.Color("orange", "   " + link + "\n");
                }
            }
        }
    }
}
