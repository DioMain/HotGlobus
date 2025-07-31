namespace HotGlobus.Core.System
{
    public class SystemBase : HotGlobusBehaviour, ISystem
    {
        /// <summary>
        /// Вызывается когда объект готов к работе
        /// </summary>
        public virtual void Ready() { }

        /// <summary>
        /// Вызывается для очитки объекта
        /// </summary>
        public virtual void Dispose() { }
    }
}
