using System;
using System.Collections.Generic;
using DIPatterns.Factory.Contracts.Interfaces;
using HtmlAgilityPack;

namespace DIPatterns.Factory.Engines
{
    class AMainSearchLinkParserEngine :ISearchLinkParserEngine
    {
        public string[] GetProductUrls(string pageContents)
        {
            // Grab the first product in the list...
            // This is the XPath to the Part Number in the search result list
            // //*[@id="productsview"]/div/div[2]/a
            var urls = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(pageContents);

            var linkNode = doc.DocumentNode.SelectSingleNode(@"//*[@id='productsview']/div/div[2]/a");

            if (linkNode != null)
            {
                string url = linkNode.GetAttributeValue("href", "");
                if (!String.IsNullOrEmpty(url))
                {
                    if (url.StartsWith("http"))
                    {
                        urls.Add(url);
                    }
                    else
                    {
                        urls.Add("http://www.amain.com" + url);                    
                    }
                }
            }

            return urls.ToArray();
        }

        public string GetSearchUrl(string brand, string productCode, string industryCode)
        {
            return String.Format(@"http://www.amain.com/search?cID=&s={0}", industryCode);
        }
    }
}
