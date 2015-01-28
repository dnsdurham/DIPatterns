using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIPatterns.Factory.Contracts.Interfaces;

namespace DIPatterns.Factory.Tests.ManagerTests.Mocks
{
    class MockEngineFactory : IEngineFactory
    {
        public T CreateEngine<T>() where T : class
        {
            if (typeof(T) == typeof(IWebPageEngine))
                return new MockWebPageEngine() as T;

            throw new ArgumentException(typeof(T).Name + " is not supported by this factory");

        }

        public T CreateSiteEngine<T>(Contracts.Common.WebstoreSite site) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
