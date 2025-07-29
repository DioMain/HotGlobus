using HotGlobus.Common;
using HotGlobus.Core;

namespace HotGlobus
{
    public class LocalManager : LocalManagerCommon
    {
        public override void Initialize()
        {
            GameManager.Instance.DependencyInjection.Singletons.Add(this);

            base.Initialize();
        }
    }
}
