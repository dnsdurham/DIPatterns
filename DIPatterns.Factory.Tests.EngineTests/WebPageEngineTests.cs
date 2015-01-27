using DIPatterns.Factory.Contracts.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIPatterns.Factory.Engines;

namespace DIPatterns.Factory.Tests.EngineTests
{
    [TestClass]
    public class WebPageEngineTests
    {
        [TestMethod]
        public void WebPageEngine_GetWebPageContents()
        {
            var factory = new EngineFactory();
            var engine = factory.CreateEngine<IWebPageEngine>();

            string contents = engine.GetWebPageContents(@"http://www.google.com", false);
            Assert.AreNotEqual(0, contents.Length);
        }
    }
}
