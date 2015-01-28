using DIPatterns.Factory.Accessors;
using DIPatterns.Factory.Engines;

namespace DIPatterns.Factory.Managers
{
    public abstract class ManagerBase
    {
        protected EngineFactory EngineFactory { get; private set; }
        protected AccessorFactory AccessorFactory { get; private set; }

        protected ManagerBase()
        {
            EngineFactory = new EngineFactory();
            AccessorFactory = new AccessorFactory();
        }

    }
}
