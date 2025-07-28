using UnityEngine;

namespace HotGlobus.Core.Container
{
    public class ContainerBase : HotGlobusBehaviour, IContainer
    {
        public virtual void Dispose() { }
    }
}
