using System.Collections.Generic;
using DIPatterns.Factory.Contracts.DataContracts;
using DIPatterns.Factory.Contracts.Interfaces;

namespace DIPatterns.Factory.Managers
{
    public class PriceCrawlManager : ManagerBase
    {
        //TODO: make this class private and implement an interface
        public Product[] GetProductPricingUsingSearch(string brand, string productCode, string industryCode, bool useProxy, string connString)
        {
            // TODO: Need to refactor this so it is not so repetitive. Possibly pass in references to the engines and make the workflow here generic

            // TODO: Once we have searched and identified a product page url we should not need to search for subsequent price refreshes. 
            // TODO: Consider breaking these calls out into discrete site-specific calls.
            var products = new List<Product>();

            // Get the amazon product pricing
            var pageEngine = EngineFactory.CreateEngine<IWebPageEngine>();
            var amznSearchParser = EngineFactory.CreateSiteEngine<ISearchLinkParserEngine>("Amazon");
            var amznProductParser = EngineFactory.CreateSiteEngine<IProductParserEngine>("Amazon");
            var productAccessor = AccessorFactory.CreateAccessor<IProductAccessor>();

            string[] urls = amznSearchParser.GetProductUrls(pageEngine.GetWebPageContents(amznSearchParser.GetSearchUrl(brand, productCode, industryCode), useProxy));
            // NOTE: for Amazon we are assuming that if more than 1 result returned then exact match not found so skip
            if (urls.Length > 0) 
            {
                // Assume the first product in the result is the product in question
                // TODO: make this a little more robust in handling multiple search results coming back
                var product = amznProductParser.GetProductInfo(pageEngine.GetWebPageContents(urls[0], useProxy), brand, productCode, industryCode);
                if (product != null)
                {
                    product.ProductUrl = urls[0];
                    product.ProductCode = industryCode;
                    product.Brand = brand;
                    products.Add(product);
                    productAccessor.Save(connString, product);
                }
            }

            // Get the amain product pricing
            var amainSearchParser = EngineFactory.CreateSiteEngine<ISearchLinkParserEngine>("AMain");
            var amainProductParser = EngineFactory.CreateSiteEngine<IProductParserEngine>("AMain");

            urls = amainSearchParser.GetProductUrls(pageEngine.GetWebPageContents(amainSearchParser.GetSearchUrl(brand, productCode, industryCode), useProxy));
            if (urls.Length > 0)
            {
                // Assume the first product in the result is the product in question
                // TODO: make this a little more robust in handling multiple search results coming back
                var product = amainProductParser.GetProductInfo(pageEngine.GetWebPageContents(urls[0], useProxy), brand, productCode, industryCode);
                if (product != null)
                {
                    product.ProductUrl = urls[0];
                    product.ProductCode = industryCode;
                    product.Brand = brand;
                    products.Add(product);
                    productAccessor.Save(connString, product);
                }
            }

            return products.ToArray();
        }
    }

}
