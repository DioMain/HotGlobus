using HotGlobus.Core.DI;
using HotGlobus.Core.System;
using UnityEngine;

namespace HotGlobus
{
    public class TestSystem : SystemBase
    {
        [Inject]
        private readonly TestHelper _testHelper;

        [Inject]
        private readonly TestServiceOuther _testService;

        [Inject]
        private readonly TestModel _model;

        [Inject]
        private readonly TestScriptableModel _testScriptableModel;

        [Inject]
        private readonly LocalManager _local;

        [Inject]
        private readonly GlobalManager _global;

        public override void Ready()
        {
            string hasGlobal = _global != null ? "YES" : "NO";
            Debug.Log($"GLOBAL: {hasGlobal}");

            string hasLocal = _local != null ? "YES" : "NO";
            Debug.Log($"LOCAL: {hasLocal}");

            Debug.Log($"model: {_model.message}");
            Debug.Log($"scriptable model: {_testScriptableModel.message}");

            _testService.Test();

            _testHelper.Test();
        }
    }
}
