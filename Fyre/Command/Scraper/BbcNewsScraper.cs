using Fyre.Console.Command.Parser;

namespace Fyre.Console.Command.Scraper
{
    /// <summary>
    /// Scraper for BBC News.
    /// </summary>
    public class BbcNewsScraper : BaseScraper
    {
        /// <summary>
        /// Execute the scraper.
        /// </summary>
        /// <param name="siteUrl">The URL for the BBC News RSS feed.</param>
        /// <param name="daysInput">The number of days worth or retrospective results.</param>
        public static void Execute(string siteUrl, int daysInput)
        {
            var document = ScrapeWebsite(siteUrl);

            var articles = GetScrapeResults(document); 
            
            BbcNewsParser.ParseResults(articles, daysInput);
        }
    }
}
