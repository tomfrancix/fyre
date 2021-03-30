using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp.Dom;
using Fyre.Console.Functions;

namespace Fyre.Console.Command.Parser
{
    /// <summary>
    /// Parser for BBC News.
    /// </summary>
    public class BbcNewsParser
    {
        /// <summary>
        /// Parse the results for BBC news.
        /// </summary>
        /// <param name="articleLink">The URL for the BBC News RSS feed.</param>
        /// <param name="daysInput">The number of days of retrospective results.</param>
        public static void ParseResults(IEnumerable<IElement> articleLink, int daysInput)
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
