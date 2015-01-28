using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Contracts.DataContracts;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockAmazonProductParserEngine : IProductParserEngine
    {
        public Product GetProductInfo(string productPageContents, string brand, string productCode, string industryCode)
        {
            throw new NotImplementedException();
        }
    }
}
