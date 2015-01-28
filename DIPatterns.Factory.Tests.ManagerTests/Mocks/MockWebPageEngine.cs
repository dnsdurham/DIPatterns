using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIPatterns.Factory.Contracts.Interfaces;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockWebPageEngine : IWebPageEngine
    {
        public const string PageContents = "Valid Web Page Contents";
        public string GetWebPageContents(string url, bool useProxy = true)
        {
            if (url.StartsWith("http://"))
            {
                return PageContents;
            }
            return "";
        }
    }
}
