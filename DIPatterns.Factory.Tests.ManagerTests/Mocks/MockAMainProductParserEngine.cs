﻿using System;
using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Contracts.DataContracts;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockAMainProductParserEngine : IProductParserEngine
    {
        public Product GetProductInfo(string productPageContents, string brand, string productCode, string industryCode)
        {
            var product = MockProduct.GetMockProduct();
            product.Site = "AMain";
            return product;
        }
    }
}
