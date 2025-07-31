using HotGlobus.Core.Container;

namespace HotGlobus.Core.Manager
{
    public class SimpleManager : ManagerBase<SimpleContainer>
    {
        public SimpleManager(SimpleContainer container) : base(container)
        {
        }
    }
}
