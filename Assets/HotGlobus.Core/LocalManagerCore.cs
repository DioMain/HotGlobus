using HotGlobus.Core.DI;
using HotGlobus.Core.Kernel;
using HotGlobus.Core.Service;

namespace HotGlobus.Core 
{
    public class LocalManagerCore : HotGlobusBehaviour, IKernel, IInjectable
    {
        protected DependencyInjectionKernel DI => GameManager.Instance.DependencyInjection;

        public virtual void Initialize()
        {

        }
    }
}
