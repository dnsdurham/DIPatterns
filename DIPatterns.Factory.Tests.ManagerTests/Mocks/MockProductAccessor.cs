using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Contracts.DataContracts;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockProductAccessor : IProductAccessor
    {
        public Product Save(string connString, Contracts.DataContracts.Product product)
        {
            throw new NotImplementedException();
        }
    }
}
