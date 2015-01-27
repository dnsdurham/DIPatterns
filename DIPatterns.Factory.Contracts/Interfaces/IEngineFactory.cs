namespace DIPatterns.Factory.Contracts.Interfaces
{
    public interface IEngineFactory
    {
        T CreateEngine<T>() where T : class;
        T CreateSiteEngine<T>(string siteName) where T : class;
    }
}
