using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIPatterns.Factory.Managers;

namespace DIPatterns.Factory.Tests.ManagerTests
{
    [TestClass]
    public class PriceCrawlManagerTests
    {
        [TestMethod]
        public void PriceCrawlManager_GetProductPricingUsingSearchTests()
        {
            var mgr = new PriceCrawlManager();

            // overide the factories
            mgr.AccessorFactory = new Mocks.MockAccessorFactory();
            mgr.EngineFactory = new Mocks.MockEngineFactory();

            var products = mgr.GetProductPricingUsingSearch("Tyco", "1234", "TYC1234", false, "connection string");

            Assert.AreEqual(2, products.Length);
            Assert.AreEqual(Mocks.MockProduct.GetMockProduct().Id, 1);

        }
    }
}
