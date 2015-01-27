namespace DIPatterns.Factory.Contracts.Interfaces
{
    public interface ISearchLinkParserEngine
    {
        string[] GetProductUrls(string pageContents);
        string GetSearchUrl(string brand, string productCode, string industryCode);
    }
}
