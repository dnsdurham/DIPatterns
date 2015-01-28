using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIPatterns.Factory.Contracts.Interfaces;

namespace DIPatterns.Factory.Managers
{
    public class ManagerFactory : IManagerFactory
    {
        public T CreateManager<T>() where T : class
        {
            if (typeof(T) == typeof(IPriceCrawlManager))
                return new PriceCrawlManager() as T;

            throw new ArgumentException(typeof(T).Name + " is not supported by this factory");
        }
    }
}
