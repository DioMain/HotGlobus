using HotGlobus.Core.Container;

namespace HotGlobus.Core.Manager
{
    public abstract class SimpleManagerBase : ManagerBase<SimpleContainer>
    {
        public SimpleManagerBase(SimpleContainer container) : base(container)
        {
        }
    }
}
