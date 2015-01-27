using System.Net;
using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Contracts.DataContracts;
using HtmlAgilityPack;

namespace DIPatterns.Factory.Engines
{
    class AmazonProductParserEngine : IProductParserEngine
    {
        public Product GetProductInfo(string productPageContents, string brand, string productCode, string industryCode)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(productPageContents);

            // TODO: Just getting the price and product name for now. Get other attributes later
            // //*[@id="priceblock_ourprice"]
            // //*[@id="productTitle"]

            HtmlNode priceNode = doc.DocumentNode.SelectSingleNode(@"//*[@id='priceblock_ourprice']");
            if (priceNode==null)
            {
                // look for "sale price" of "our price" not found
                priceNode = doc.DocumentNode.SelectSingleNode(@"//*[@id='priceblock_saleprice']");
            }

            HtmlNode nameNode = doc.DocumentNode.SelectSingleNode(@"//*[@id='productTitle']");

            // TODO: add better logic for determining whether the actual product was found
            // Look for model number in page contents

            var product = new Product
            {
                Brand = "Unknown",
                ListPrice = "$0.00",
                Price = priceNode != null ? WebUtility.HtmlDecode(priceNode.InnerText.Trim()) : "-1.00",
                ProductName = nameNode != null ? WebUtility.HtmlDecode(nameNode.InnerText.Trim()) : "Unknown",
                Site = "Amazon"
            };

            return product;
        }
    }
}
