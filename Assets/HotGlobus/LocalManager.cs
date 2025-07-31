using HotGlobus.Common;
using HotGlobus.Core.Container;
using UnityEngine;

namespace HotGlobus
{
    public class LocalManager : LocalManagerCommon
    {
        [SerializeField]
        private SimpleContainer testContainer;

        public override void Initialize()
        {
            base.Initialize();

            testContainer.Initialize();
        }
    }
}
