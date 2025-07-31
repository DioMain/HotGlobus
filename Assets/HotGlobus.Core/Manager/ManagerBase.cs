using HotGlobus.Core.Container;

namespace HotGlobus.Core.Manager
{
    public abstract class ManagerBase<T> : IManager<T>
        where T : IContainer
    {
        private readonly T container;
        public T Container => container;

        public ManagerBase(T container)
        {
            this.container = container;
        }
    }
}
