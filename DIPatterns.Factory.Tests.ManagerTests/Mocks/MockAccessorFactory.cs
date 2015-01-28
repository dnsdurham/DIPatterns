using System;
using DIPatterns.Factory.Contracts.Interfaces;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockAccessorFactory : IAccessorFactory
    {
        public T CreateAccessor<T>() where T : class
        {
            if (typeof(T) == typeof(IProductAccessor))
                return new MockProductAccessor() as T;

            throw new ArgumentException(typeof(T).Name + " is not supported by this factory");

        }
    }
}
