using System.IO;
using DIPatterns.Factory.Contracts.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIPatterns.Factory.Engines;

namespace DIPatterns.Factory.Tests.EngineTests
{
    [TestClass]
    public class ProductParserEngineTests
    {
        // Deployment Items reference:
        // http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.deploymentitemattribute.aspx

        [TestMethod]
        [DeploymentItem(@"Resources\AmazonProductPage.txt")]
        public void AmazonProductParserEngine_GetProductInfo()
        {
            var factory = new EngineFactory();
            var engine = factory.CreateSiteEngine<IProductParserEngine>("Amazon");

            Assert.IsTrue(File.Exists("AmazonProductPage.txt"));

            var product = engine.GetProductInfo(File.ReadAllText("AmazonProductPage.txt"), "Bachmann", "00691", "BAC00691");

            // TODO: Add tests for the other attributes parsed from the page
            Assert.AreEqual("$64.50", product.Price);
            Assert.AreEqual("Bachmann Trains Thoroughbred Ready-to-Run HO Scale Train Set", product.ProductName);
            Assert.AreEqual("Amazon", product.Site);
        }

        [TestMethod]
        [DeploymentItem(@"Resources\AMainProductPage.txt")]
        public void AMainProductParserEngine_GetProductInfo()
        {
            var factory = new EngineFactory();
            var engine = factory.CreateSiteEngine<IProductParserEngine>("AMain");

            Assert.IsTrue(File.Exists("AMainProductPage.txt"));

            var product = engine.GetProductInfo(File.ReadAllText("AMainProductPage.txt"), "Bachmann", "00691", "BAC00691");

            // TODO: Add tests for the other attributes parsed from the page
            Assert.AreEqual("$82.99", product.Price);
            Assert.AreEqual("Bachmann HO-Scale Thoroughbred Train Set (Norfolk Southern)", product.ProductName);
            Assert.AreEqual("AMain", product.Site);
        }
    }
}
