using HotGlobus.Core.DI;
using System;

namespace HotGlobus.Core.Interfaces
{
    public interface ILogicEndPoint : IInjectTarget, IDisposable
    {
        public void Ready();
    }
}
