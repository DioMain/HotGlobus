using HotGlobus.Core.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace HotGlobus.Core.DI
{
    public class DependencyInjectionKernel : IKernel
    {
        private readonly Assembly _assembly;
        private readonly Type[] _globalInjectables;

        public List<IInjectable> Singletons { get; private set; }

        public DependencyInjectionKernel()
        {
            _assembly = GetType().Assembly;

            _globalInjectables = _assembly.GetTypes().Where(t => typeof(IGlobalInjectable).IsAssignableFrom(t)
                                                                 && t.IsClass && !t.IsAbstract)
                                                     .ToArray();

            Singletons = new List<IInjectable>();
        }

        public void InjectInto(IInjectTarget target, params IInjectable[] additionalDependencies)
        {
            FieldInfo[] injectFields = target.GetType().GetFields()
                                                       .Where(f => f.IsDefined(typeof(Inject)))
                                                       .ToArray();

            foreach (var field in injectFields)
            {
                IInjectable injectable = null;

                injectable = additionalDependencies.FirstOrDefault(i => i.GetType() == field.FieldType);

                injectable ??= Singletons.FirstOrDefault(s => s.GetType() == field.FieldType);

                if (injectable == null)
                {
                    Type injectableType = _globalInjectables.FirstOrDefault(gi => gi == field.FieldType);

                    if (injectableType == null)
                    {
                        Debug.LogError($"Зависимость не найдена: [{field.Name}, {field.FieldType.Name}]");
                        break;
                    }

                    injectable = (IInjectable)GetDependency(injectableType);

                    if (injectable is IInjectTarget subTarget)
                    {
                        InjectInto(subTarget, additionalDependencies);
                    }
                }

                field.SetValue(target, injectable);    
            }
        }

        public object GetDependency(Type depencencyType)
        {
            return Activator.CreateInstance(depencencyType);
        }

        public T GetDependency<T>() where T : IInjectable
        {
            return (T)GetDependency(typeof(T));
        }
    }
}
