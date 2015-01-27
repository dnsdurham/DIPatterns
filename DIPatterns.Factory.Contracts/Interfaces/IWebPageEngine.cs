namespace DIPatterns.Factory.Contracts.Interfaces
{
    public interface IWebPageEngine
    {
        string GetWebPageContents(string url, bool useProxy = true);
    }
}
