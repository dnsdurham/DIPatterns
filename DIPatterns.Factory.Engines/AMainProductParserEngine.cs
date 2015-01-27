using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Contracts.DataContracts;
using HtmlAgilityPack;
using System.Net;

namespace DIPatterns.Factory.Engines
{
    class AMainProductParserEngine :IProductParserEngine
    {
        public Product GetProductInfo(string productPageContents, string brand, string manNumber, string htupn)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(productPageContents);

            // TODO: Just getting the price and product name for now. Get other attributes later
            // TODO: These XPath queries are probably not robust enough to handle slight variations in the markup
            // Product Price (query is reliant on showing list, savings, etc)
            // //*[@id="productpage"]/div[4]/div[3]/table/tbody/tr[3]/td/span 
            // NOTE: "tbody" must be removed from XPath queries when using HtmlAgilityPack
            //var priceNode = doc.DocumentNode.SelectSingleNode(@"//*[@id='productpage']/div[4]/div[3]/table/tr[3]/td/span");
            // Table containg price has variable rows so modified to simply look for a node with a class == "theprice"
            var priceNode = doc.DocumentNode.SelectSingleNode(@"//*[@class='theprice']");
            // Product name
            // //*[@id="productpage"]/div[3]/div[1]/div[2]/h1
            var nameNode = doc.DocumentNode.SelectSingleNode(@"//*[@id='productpage']/div[3]/div[1]/div[2]/h1");

            var product = new Product
            {
                Brand = "Unknown",
                ListPrice = "$0.00",
                Price = priceNode != null ? WebUtility.HtmlDecode(priceNode.InnerText.Trim()) : "-1.00",
                ProductName = nameNode != null ? WebUtility.HtmlDecode(nameNode.InnerText.Trim()) : "Unknown",
                Site = "AMain"
            };

            return product;

        }
    }
}
