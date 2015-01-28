using DIPatterns.Factory.Contracts.DataContracts;

namespace DIPatterns.Factory.Managers
{
    public interface IPriceCrawlManager
    {
        Product[] GetProductPricingUsingSearch(string brand, string productCode, string industryCode, bool useProxy, string connString);
    }
}