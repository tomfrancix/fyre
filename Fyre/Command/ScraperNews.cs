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
using Fyre.Console.Command.Parser;
using Fyre.Console.Command.Scraper;
using Fyre.Console.Data.Descriptor;
using Fyre.Console.Data.Model;
using Fyre.Console.Functions;
using Fyre.Console.Repository;

namespace Fyre.Console.Command
{
    /// <summary>
    /// This command scrapes news websites.
    /// </summary>
    public class ScraperNews
    {
        /// <summary>
        /// Execute the scraper.
        /// </summary>
        public static void Execute()
        {
            Print.Color("yellow", "Scraping BBC UK news...");

            System.Console.WriteLine("How many days retrospectively?");

            var daysString = System.Console.ReadLine();

            var daysInput = Convert.ToInt32(daysString);

            var siteUrl = "http://feeds.bbci.co.uk/news/rss.xml";

            BbcNewsScraper.Execute(siteUrl, daysInput);
        }
    }
}
