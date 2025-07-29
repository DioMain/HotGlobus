using HotGlobus.Common;
using HotGlobus.Core.DI;
using HotGlobus.Core.Model;
using UnityEngine;

namespace HotGlobus.Core.Service
{
    public class TestService : ServiceBase
    {
        [Inject]
        private GlobalManagerCommon _globalCommon;
        [Inject]
        private LocalManagerCommon _localCommon;

        [Inject]
        private GlobalManager _global;
        [Inject]
        private LocalManager _local;

        [Inject]
        private TestService1 _testService1;

        public void Test()
        {
            Debug.Log(Game);

            Debug.Log("GCore " + GlobalCore);
            Debug.Log("LCore " + LocalCore);

            Debug.Log("GCommon " + _globalCommon);
            Debug.Log("LCommon " + _localCommon);

            Debug.Log("G " + _global);
            Debug.Log("L " + _local);

            _testService1.Test();
        }
    }
}
