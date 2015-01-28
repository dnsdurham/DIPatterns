
using DIPatterns.Factory.Contracts.Interfaces;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockAMainSearchLinkParserEngine : ISearchLinkParserEngine
    {
        public string[] GetProductUrls(string pageContents)
        {
            if (pageContents.Length > 0)
            {
                return new string[] {@"http://tyco.com/cool-train"};
            }
            return null;
        }

        public string GetSearchUrl(string brand, string productCode, string industryCode)
        {
            return @"http://tyco.com/search";
        }
    }
}
