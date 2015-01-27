using DIPatterns.Factory.Contracts.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIPatterns.Factory.Engines;
using System.IO;

namespace DIPatterns.Factory.Tests.EngineTests
{
    [TestClass]
    public class SearchLinkParserEngineTests
    {
        // Deployment Items reference:
        // http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.deploymentitemattribute.aspx

        #region GetProductUrls 
       
        [TestMethod]
        [DeploymentItem(@"Resources\AmazonSearchResults.txt")]
        public void AmazonSearchLinkParserEngine_GetProductUrls()
        {
            var factory = new EngineFactory();
            var engine = factory.CreateSiteEngine<ISearchLinkParserEngine>("Amazon");

            Assert.IsTrue(File.Exists("AmazonSearchResults.txt"));

            var urls = engine.GetProductUrls(File.ReadAllText("AmazonSearchResults.txt"));

            Assert.AreEqual(24, urls.Length);
            Assert.AreEqual(@"http://www.amazon.com/gp/product/B001RG7LDU/", urls[0]);
            Assert.AreEqual(@"http://www.amazon.com/gp/product/B0000CGB0P/", urls[23]);
        }

        [TestMethod]
        [DeploymentItem(@"Resources\AMainSingleSearchResult.txt")]
        public void AMainSearchLinkParserEngine_GetProductUrls()
        {
            var factory = new EngineFactory();
            var engine = factory.CreateSiteEngine<ISearchLinkParserEngine>("AMain");

            Assert.IsTrue(File.Exists("AMainSingleSearchResult.txt"));

            var urls = engine.GetProductUrls(File.ReadAllText("AMainSingleSearchResult.txt"));

            Assert.AreEqual(1, urls.Length);
            Assert.AreEqual(@"http://www.amain.com/bachmann-ho-scale-thoroughbred-train-set-norfolk-southern/p47395", urls[0]);

        }

        #endregion

        #region GetSearchUrl

        [TestMethod]
        public void AmazonSearchLinkParserEngine_GetSearchUrl()
        {
            var factory = new EngineFactory();
            var engine = factory.CreateSiteEngine<ISearchLinkParserEngine>("Amazon");

            Assert.AreEqual(@"http://www.amazon.com/gp/search/ref=sr_adv_toys/?search-alias=toys-and-games&unfiltered=1&field-keywords=00691&field-brand=Bachmann&node=&field-price=&field-age_range=&sort=relevancerank&Adv-Srch-Toys-Submit.x=23&Adv-Srch-Toys-Submit.y=8", engine.GetSearchUrl("Bachmann", "00691", "BAC00691"));
        }

        [TestMethod]
        public void AMainSearchLinkParserEngine_GetSearchUrl()
        {
            var factory = new EngineFactory();
            var engine = factory.CreateSiteEngine<ISearchLinkParserEngine>("AMain");

            Assert.AreEqual(@"http://www.amain.com/search?cID=&s=BAC00691", engine.GetSearchUrl("Bachmann", "00691", "BAC00691"));

        }

        #endregion
    }
}
