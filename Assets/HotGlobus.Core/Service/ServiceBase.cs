using HotGlobus.Core.DI;

namespace HotGlobus.Core.Service
{
    public abstract class ServiceBase : IService
    {
        protected GameManager Game => GameManager.Instance;

        protected GlobalManagerCore GlobalCore => Game.Global;

        protected LocalManagerCore LocalCore => Game.Local;
    }
}
