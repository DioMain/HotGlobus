using UnityEngine;

namespace HotGlobus.Core.View
{
    public class ViewBase : HotGlobusBehaviour, IView
    {
        protected RectTransform RectTransform { get; private set; }


        public virtual void Start()
        {
            RectTransform = GetComponent<RectTransform>();
        }

        public virtual void Ready() { }

        public virtual void Dispose() { }
    }
}
