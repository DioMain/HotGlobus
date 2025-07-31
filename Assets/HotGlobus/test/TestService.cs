using HotGlobus.Core.DI;
using HotGlobus.Core.Service;
using UnityEngine;

namespace HotGlobus
{
    public class TestServiceOuther : ServiceBase
    {
        [Inject]
        private readonly TestServiceInner _inner;

        public void Test()
        {
            Debug.Log("Outher service work!");

            _inner.Test();
        }
    }

    public class TestServiceInner : ServiceBase
    {
        public void Test()
        {
            Debug.Log("Inner service work!");
        }
    }
}
