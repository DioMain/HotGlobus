using HotGlobus.Core;
using HotGlobus.Core.DI;

namespace HotGlobus.Common
{
    public class GlobalManagerCommon : GlobalManagerCore, IInjectable
    {
        public override void Initialize()
        {
            GameManager.Instance.DependencyInjection.Singletons.Add(this);

            base.Initialize();
        }
    }
}
