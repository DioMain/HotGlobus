using HotGlobus.Core.Container;

namespace HotGlobus.Core.Manager
{
    public abstract class ManagerBase<T> : IManager<T>
        where T : IContainer
    {
        protected T Container { get; private set; }

        public ManagerBase(T container)
        {
            Container = container;
        }
    }
}
