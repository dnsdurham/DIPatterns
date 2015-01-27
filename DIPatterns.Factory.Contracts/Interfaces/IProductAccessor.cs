using DIPatterns.Factory.Contracts.DataContracts;

namespace DIPatterns.Factory.Contracts.Interfaces
{
    public interface IProductAccessor
    {
        Product Save(string connString, Product product);
    }

}
