using System;
using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Contracts.DataContracts;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockProductAccessor : IProductAccessor
    {
        public Product TestProduct { get; private set; }

        public MockProductAccessor()
        {
            TestProduct = new Product()
            {
                Brand = "Tyco",
                Id = 1,
                ListPrice = "$2.00",
                Price = "$1.00",
                ProductCode = "1234",
                ProductName = "Cool Train",
                ProductUrl = "http://tyco.com/cool-train",
                Site = "Toy Barn"
            };    
        }
        
        public Product Save(string connString, Product product)
        {
            return TestProduct;
        }
    }
}
