using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HotGlobus.Core.Container
{
    public class SimpleContainer : ContainerBase
    {
        [Header("Подконтейнеры")]
        [SerializeField]
        private List<ContainerBase> containers = new();

        public IContainer FindSubContainerByTag(string tag)
        {
            return containers.FirstOrDefault(c => c.ContainerTag == tag);
        }

        public T FindSubContainerByType<T>() where T : IContainer
        {
            return containers.OfType<T>().FirstOrDefault();
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var container in containers)
                container.Initialize();
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (var container in containers)
                container.Dispose();
        }
    }
}
