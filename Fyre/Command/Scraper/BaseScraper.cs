using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Fyre.Console.Command.Parser;

namespace Fyre.Console.Command.Scraper
{
    /// <summary>
    /// Base class for web scrapers.
    /// </summary>
    public class BaseScraper
    {
        /// <summary>
        /// Download the HTML document from a given URL.
        /// </summary>
        /// <param name="siteUrl">The URL of the website.</param>
        /// <returns>The HTML document.</returns>
        internal static async Task<IHtmlDocument> ScrapeWebsite(string siteUrl)
        {
            var cancellationToken = new CancellationTokenSource();
            var httpClient = new HttpClient();

            var request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            var response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(response);

            return document;
        }

        /// <summary>
        /// Return all the elements on the page.
        /// </summary>
        /// <param name="documentTask">The HTML document.</param>
        /// <returns>The elements on the webpage.</returns>
        public static IEnumerable<IElement> GetScrapeResults(Task<IHtmlDocument> documentTask)
        {
            IHtmlDocument document = documentTask.Result;

            IEnumerable<IElement> articleLink = document.All;

            return articleLink.Any() ? articleLink : new IElement[0];
        }
    }
}
