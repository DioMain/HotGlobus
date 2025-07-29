using HotGlobus.Common;
using HotGlobus.Core.Service;

namespace HotGlobus
{
    public class LocalManager : LocalManagerCommon
    {
        public override void Initialize()
        {
            base.Initialize();

            var testService = new TestService();

            DI.InjectInto(testService);

            testService.Test();
        }
    }
}
