using System;

namespace HotGlobus.Core.Model
{
    public abstract class ModelBase : HotGlobusBehaviour, IModel, IDisposable
    {
        public virtual void Dispose() { }
    }
}
