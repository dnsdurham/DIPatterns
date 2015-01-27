using DIPatterns.Factory.Contracts.Common;

namespace DIPatterns.Factory.Contracts.Interfaces
{
    public interface IEngineFactory
    {
        T CreateEngine<T>() where T : class;
        T CreateSiteEngine<T>(WebstoreSite site) where T : class;
    }
}
