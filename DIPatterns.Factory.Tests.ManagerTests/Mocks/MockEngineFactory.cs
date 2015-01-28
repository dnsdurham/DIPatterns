using System;
using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Contracts.Common;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockEngineFactory : IEngineFactory
    {
        public T CreateEngine<T>() where T : class
        {
            if (typeof(T) == typeof(IWebPageEngine))
                return new MockWebPageEngine() as T;

            throw new ArgumentException(typeof(T).Name + " is not supported by this factory");

        }

        public T CreateSiteEngine<T>(Contracts.Common.WebstoreSite site) where T : class
        {
            // Site specific search result parsers
            if (typeof(T) == typeof(ISearchLinkParserEngine))
            {
                switch (site)
                {
                    case WebstoreSite.Amazon:
                        return new MockAmazonSearchLinkParserEngine() as T;
                    case WebstoreSite.AMain:
                        return new MockAMainSearchLinkParserEngine() as T;
                    default:
                        throw new ArgumentException("This site is not supported by this factory");
                }

            }

            // Site-specific product parsers
            if (typeof(T) == typeof(IProductParserEngine))
            {
                switch (site)
                {
                    case WebstoreSite.Amazon:
                        return new MockAmazonProductParserEngine() as T;
                    case WebstoreSite.AMain:
                        return new MockAMainProductParserEngine() as T;
                    default:
                        throw new ArgumentException("This site is not supported by this factory");
                }
            }

            throw new ArgumentException("This interface is not supported by this factory");

        }
    }
}
