
namespace DIPatterns.Factory.Contracts.Interfaces
{
    public interface IAccessorFactory
    {
        T CreateAccessor<T>() where T : class;
    }
}
