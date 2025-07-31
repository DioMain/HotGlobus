using HotGlobus.Core.DI;

namespace HotGlobus.Core.Manager
{
    public interface IManager<T> : IInjectTarget
    {
        public T Container { get; }
    }
}
