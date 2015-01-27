using DIPatterns.Factory.Contracts.DataContracts;

namespace DIPatterns.Factory.Contracts.Interfaces
{
    public interface IProductParserEngine
    {
        Product GetProductInfo(string productPageContents, string brand, string productCode, string industryCode);
    }
}
