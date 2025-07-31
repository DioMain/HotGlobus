using HotGlobus.Core.Model;
using HotGlobus.Core.System;
using HotGlobus.Core.View;
using System;

namespace HotGlobus.Core.Container
{
    public interface IContainer : IDisposable
    {
        public string ContainerTag { get; }

        public T GetModel<T>() where T : ModelBase;
        public T GetScriptableModel<T>() where T : ScriptableModelBase;
        public T GetSystem<T>() where T : ISystem;

        public T GetViewModel<T>() where T : ViewModelBase;
        public T GetView<T>() where T : IView;

        /// <summary>
        /// Может использоваться для добавления как и обычной так и view модели
        /// </summary>
        public void AddModel(ModelBase model);
        public void AddScriptableModel(ScriptableModelBase model);
        public void AddSystem(ISystem system);
        public void AddView(IView model);

        public IContainer FindContainerInChildrensByTag(string tag);

        public T FindContainerInChildrensByType<T>() where T : IContainer;

        public void Initialize();
    }
}
