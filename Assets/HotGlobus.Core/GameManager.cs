using HotGlobus.Core.DI;
using HotGlobus.Core.Kernel;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HotGlobus.Core
{
    public class GameManager : HotGlobusBehaviour, IKernel
    {
        public static GameManager Instance;

        public const string LocalTag = "SceneController";

        public bool GlobalIsReady { get; private set; }

        public DependencyInjectionKernel DependencyInjection { get; private set; }

        public LocalManagerCore Local { get; private set; }

        [SerializeField]
        private GlobalManagerCore globalInstance;
        public GlobalManagerCore Global => globalInstance;

        private Coroutine delayedLocalInitializeCoroutine = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(gameObject);

                SceneManager.activeSceneChanged += OnSceneChanged;

                Initialize();
            }
            else
                Destroy(gameObject);
        }

        private void Initialize()
        {
            DependencyInjection = new DependencyInjectionKernel();

            GlobalIsReady = false;

            DependencyInjection.Singletons.Add(Global);

            Global.Initialize();

            GlobalIsReady = true;
        }

        private void OnSceneChanged(Scene old, Scene scene)
        {
            if (!scene.isLoaded)
                return;

            if (Local != null && DependencyInjection.Singletons.Contains(Local))
                DependencyInjection.Singletons.Remove(Local);

            if (delayedLocalInitializeCoroutine != null)
                StopCoroutine(delayedLocalInitializeCoroutine);

            delayedLocalInitializeCoroutine = StartCoroutine(DelayedLocalInitialize());
        }

        private IEnumerator DelayedLocalInitialize()
        {
            yield return new WaitWhile(() => !GlobalIsReady);

            Local = GameObject.FindWithTag(LocalTag).GetComponent<LocalManagerCore>();

            DependencyInjection.Singletons.Add(Local);

            Local.Initialize();
        }
    }
}
