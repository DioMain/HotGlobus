using HotGlobus.Core.DI;
using HotGlobus.Core.Model;
using HotGlobus.Core.System;
using HotGlobus.Core.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HotGlobus.Core.Container
{
    public abstract class ContainerBase : HotGlobusBehaviour, IContainer
    {
        [Header("Настройки контейнера")]
        [SerializeField]
        private string containerTag;
        /// <summary>
        /// Дополнительный способ идентификации контейнеров
        /// </summary>
        public string ContainerTag => containerTag;

        [Header("Объекты контейнера")]
        [SerializeField]
        private List<ModelBase> models = new();

        [SerializeField]
        private List<ScriptableModelBase> scriptableModels = new();

        [SerializeField]
        private List<SystemBase> systems = new();

        [SerializeField]
        private List<ViewBase> views = new();

        /// <summary>
        /// Защищённое свойство для доступа к внедрению зависимостей
        /// </summary>
        protected DependencyInjectionKernel DI => GameManager.Instance.DependencyInjection;

        public T GetModel<T>() where T : ModelBase
        {
            return models.OfType<T>().FirstOrDefault();
        }
        public T GetScriptableModel<T>() where T : ScriptableModelBase
        {
            return scriptableModels.OfType<T>().FirstOrDefault();
        }
        public T GetSystem<T>() where T : ISystem
        {
            return systems.OfType<T>().FirstOrDefault();
        }

        public T GetViewModel<T>() where T : ViewModelBase
        {
            return GetModel<T>();
        }
        public T GetView<T>() where T : IView
        {
            return views.OfType<T>().FirstOrDefault();
        }

        public void AddModel(ModelBase model)
        {
            if (models.All(m => m.GetType() != model.GetType()))
                models.Add(model);
        }
        public void AddScriptableModel(ScriptableModelBase model)
        {
            if (scriptableModels.All(sm => sm.GetType() != model.GetType()))
                scriptableModels.Add(model);
        }
        public void AddSystem(ISystem system)
        {
            if (systems.All(s => s.GetType() != system.GetType()))
                systems.Add((SystemBase)system);
        }
        public void AddView(IView view)
        {
            if (views.All(v => v.GetType() != view.GetType()))
                views.Add((ViewBase)view);
        }

        public IContainer FindContainerInChildrensByTag(string tag)
        {
            return gameObject.GetComponentsInChildren<ContainerBase>()
                             .FirstOrDefault(c => c.ContainerTag == tag);
        }

        public T FindContainerInChildrensByType<T>() where T : IContainer
        {
            return gameObject.GetComponentInChildren<T>();
        }

        public virtual void Initialize()
        {
            var injectables = new List<IInjectable>();

            injectables.AddRange(models);
            injectables.AddRange(scriptableModels);

            foreach (var system in systems)
                DI.InjectInto(system, injectables.ToArray());

            foreach (var view in views)
                DI.InjectInto(view, injectables.ToArray());

            foreach (var system in systems)
                system.Ready();

            foreach (var view in views)
                view.Ready();
        }

        public virtual void Dispose()
        {
            foreach (var system in systems)
                system.Dispose();

            foreach (var view in views)
                view.Dispose();

            foreach (var model in models)
                model.Dispose();
        }
    }
}
