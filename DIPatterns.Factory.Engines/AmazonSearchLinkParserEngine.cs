using System;
using System.Collections.Generic;
using System.Web;
using DIPatterns.Factory.Contracts.Interfaces;
using HtmlAgilityPack;

namespace DIPatterns.Factory.Engines
{
    class AmazonSearchLinkParserEngine : ISearchLinkParserEngine
    {
        public string[] GetProductUrls(string pageContents)
        {
            // located the node containing the search results
            // //*[@id="resultsCol"]
            // use data-asin attribute of the //*[@id="result_0"] element to get the ASIN and construct amazon url from this?
            // e.g. http://www.amazon.com/gp/product/B001RG7LDU/
            var doc = new HtmlDocument();
            doc.LoadHtml(pageContents);
            bool moreResults = true;
            int resultIndex = 0;
            var urlList = new List<string>();

            // check to see if there is 
            HtmlNode noResultsNode = doc.DocumentNode.SelectSingleNode(@"//*[@id='noResultsTitle']");
            if (noResultsNode != null)
            {
                moreResults = false; // this results in an empty array returned
            }

            while (moreResults)
            {
                // located the node for the next result
                HtmlNode nameNode = doc.DocumentNode.SelectSingleNode(String.Format(@"//*[@id='result_{0}']", resultIndex));
                // if found then get the asin from the attributes
                if (nameNode != null)
                {
                    string asin = nameNode.GetAttributeValue("data-asin","");
                    if (!String.IsNullOrEmpty(asin))
                    {
                        urlList.Add(String.Format(@"http://www.amazon.com/gp/product/{0}/", asin));
                    }
                }
                else
                {
                    // indicate no more results
                    moreResults = false;
                }

                // increment index to next result
                resultIndex += 1;
            }

            return urlList.ToArray();
        }

        public string GetSearchUrl(string brand, string productCode, string industryCode)
        {
            return String.Format(@"http://www.amazon.com/gp/search/ref=sr_adv_toys/?search-alias=toys-and-games&unfiltered=1&field-keywords={0}&field-brand={1}&node=&field-price=&field-age_range=&sort=relevancerank&Adv-Srch-Toys-Submit.x=23&Adv-Srch-Toys-Submit.y=8", productCode, HttpUtility.UrlEncode(brand));
        }
    }
}
