using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPatterns.Factory.Contracts.Interfaces
{
    public interface IManagerFactory
    {
        T CreateManager<T>() where T : class;
    }
}
