using DIPatterns.Factory.Accessors;
using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Engines;

namespace DIPatterns.Factory.Managers
{
    public abstract class ManagerBase
    {
        public IEngineFactory EngineFactory { get; set; }
        public IAccessorFactory AccessorFactory { get; set; }

        protected ManagerBase()
        {
            EngineFactory = new EngineFactory();
            AccessorFactory = new AccessorFactory();
        }

    }
}
