using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIPatterns.Factory.Contracts.Interfaces;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockAmazonSearchLinkParserEngine : ISearchLinkParserEngine
    {
        public string[] GetProductUrls(string pageContents)
        {
            throw new NotImplementedException();
        }

        public string GetSearchUrl(string brand, string productCode, string industryCode)
        {
            throw new NotImplementedException();
        }
    }
}
