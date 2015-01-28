using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Contracts.DataContracts;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockProductAccessor : IProductAccessor
    {
        
        public Product Save(string connString, Product product)
        {
            return MockProduct.GetMockProduct();
        }
    }
}
