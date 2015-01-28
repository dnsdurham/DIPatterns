using System;
using DIPatterns.Factory.Contracts.Common;
using DIPatterns.Factory.Contracts.Interfaces;


namespace DIPatterns.Factory.Engines
{
    public class EngineFactory : IEngineFactory
    {
        public T CreateEngine<T>() where T : class
        {
            if (typeof(T) == typeof(IWebPageEngine))
                return new WebPageEngine() as T;

            throw new ArgumentException(typeof(T).Name + " is not supported by this factory");

        }

        public T CreateSiteEngine<T>(WebstoreSite site) where T : class
        {
            // Site specific search result parsers
            if (typeof(T) == typeof(ISearchLinkParserEngine))
            {
                switch (site)
                {
                    case WebstoreSite.Amazon:
                        return new AmazonSearchLinkParserEngine() as T;
                    case WebstoreSite.AMain:
                        return new AMainSearchLinkParserEngine() as T;
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
                        return new AmazonProductParserEngine() as T;
                    case WebstoreSite.AMain:
                        return new AMainProductParserEngine() as T;
                    default:
                        throw new ArgumentException("This site is not supported by this factory");
                }                
            }

            throw new ArgumentException("This interface is not supported by this factory");
        }
    }
}
