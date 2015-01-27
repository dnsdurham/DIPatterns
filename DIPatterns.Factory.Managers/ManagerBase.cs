﻿using DIPatterns.Factory.Accessors;
using DIPatterns.Factory.Contracts.Interfaces;
using DIPatterns.Factory.Engines;

namespace DIPatterns.Factory.Managers
{
    public abstract class ManagerBase
    {
        protected EngineFactory EngineFactory { get; private set; }
        protected AccessorFactory AccessorFactory { get; set; }

        protected ManagerBase()
        {
            EngineFactory = new EngineFactory();
            AccessorFactory = new AccessorFactory();
        }

    }
}
