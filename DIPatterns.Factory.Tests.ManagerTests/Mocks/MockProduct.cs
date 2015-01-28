
using DIPatterns.Factory.Contracts.DataContracts;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    public static class MockProduct
    {
        public static Product GetMockProduct()
        {
            return new Product()
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
    }
}
