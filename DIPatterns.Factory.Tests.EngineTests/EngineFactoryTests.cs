using System;
using DIPatterns.Factory.Contracts.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIPatterns.Factory.Engines;
using DIPatterns.Factory.Contracts.Common;

namespace DIPatterns.Factory.Tests.EngineTests
{
    [TestClass]
    public class EngineFactoryTests
    {
        [TestMethod]
        public void EngineFactory_CreateEngine()
        {
            var factory = new EngineFactory();

            // tests for each handled interface
            Assert.AreNotEqual(null, factory.CreateEngine<IWebPageEngine>());


            // tests for bad parameters
            // the following will throw an argument exception
            try
            {
                Assert.AreEqual(null, factory.CreateEngine<IFormatProvider>());
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("IFormatProvider is not supported by this factory", ex.Message);    
            }
            catch (Exception)
            {
                Assert.Fail("unexpected exception");
            }
        }

        [TestMethod]
        public void EngineFactory_CreateSiteEngine()
        {
            var factory = new EngineFactory();

            // tests for each handled site
            Assert.AreNotEqual(null, factory.CreateSiteEngine<ISearchLinkParserEngine>(WebstoreSite.Amazon));
            Assert.AreNotEqual(null, factory.CreateSiteEngine<IProductParserEngine>(WebstoreSite.Amazon));
            Assert.AreNotEqual(null, factory.CreateSiteEngine<ISearchLinkParserEngine>(WebstoreSite.AMain));
            Assert.AreNotEqual(null, factory.CreateSiteEngine<IProductParserEngine>(WebstoreSite.AMain));

            // tests for bad parameters

            // the following will throw an argument exception due to bad interface
            try
            {
                Assert.AreEqual(null, factory.CreateSiteEngine<IFormatProvider>(WebstoreSite.Amazon));
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("This interface is not supported by this factory", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("unexpected exception");
            }
        }
    }
}
