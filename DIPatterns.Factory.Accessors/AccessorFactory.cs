using System;
using DIPatterns.Factory.Contracts.Interfaces;

namespace DIPatterns.Factory.Accessors
{
    public class AccessorFactory : IAccessorFactory
    {
        public T CreateAccessor<T>() where T : class
        {
            if (typeof(T) == typeof(IProductAccessor))
                return new ProductAccessor() as T;

            throw new ArgumentException(typeof(T).Name + " is not supported by this factory");
        }
    }
}
